using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Arc.Validators.SourceGenerators;

[Generator]
public class DependencyManagerIncrementalSourceGenerator :
    IIncrementalGenerator
{
    private const string FileName =
        "DependencyManager.g.cs";

    private const string AbstractValidator =
        "AbstractValidator";

    public void Initialize(
        IncrementalGeneratorInitializationContext context
    )
    {
        var incrementalSyntaxProviders =
            context
                .SyntaxProvider
                .CreateSyntaxProvider(
                    Predicate(),
                    Transform()
                );

        var providers =
            incrementalSyntaxProviders
                .Where(
                    valueTuple =>
                        valueTuple.isValidator
                )
                .Select(
                    (
                        valueTuple,
                        _
                    ) => valueTuple.syntax
                );

        var valueProvider =
            providers.Collect();

        var incrementalValueProvider =
            context
                .CompilationProvider
                .Combine(
                    valueProvider
                );

        context
            .RegisterSourceOutput(
                incrementalValueProvider,
                Action()
            );
    }

    private static Action<SourceProductionContext, (Compilation Left, ImmutableArray<ClassDeclarationSyntax> Right)> Action() =>
        (
            context,
            valueTuple
        ) =>
            GenerateCode(
                context,
                valueTuple.Left,
                valueTuple.Right
            );

    private static Func<GeneratorSyntaxContext, CancellationToken, (ClassDeclarationSyntax syntax, bool isValidator)> Transform() =>
        (
            syntaxContext,
            _
        ) =>
            GetClassDeclaration(
                syntaxContext
            );

    private static (ClassDeclarationSyntax, bool isValidator) GetClassDeclaration(
        GeneratorSyntaxContext context
    )
    {
        var classDeclarationSyntax =
            (ClassDeclarationSyntax)context.Node;

        return
            (classDeclarationSyntax, true);
    }

    private static Func<SyntaxNode, CancellationToken, bool> Predicate() =>
        (
            syntaxNode,
            _
        ) =>
        {
            if (syntaxNode is not ClassDeclarationSyntax declaration)
            {
                return false;
            }

            var typeSyntaxList =
                declaration
                    .BaseList?
                    .Types
                    .Select(
                        baseTypeSyntax =>
                            baseTypeSyntax.Type
                    )
                    .ToArray();

            var isEmpty =
                typeSyntaxList == default
                || !typeSyntaxList.Any();

            if (isEmpty)
            {
                return false;
            }

            foreach (var typeSyntax in typeSyntaxList!)
            {
                if (typeSyntax is GenericNameSyntax identifierNameSyntax)
                {
                    var identifierText =
                        identifierNameSyntax
                            .Identifier
                            .Text;

                    var isValidator =
                        identifierText
                        == AbstractValidator;

                    if (isValidator)
                    {
                        return true;
                    }
                }
            }

            return false;
        };

    private static (string typeName, string typeNamespace) GetFirstBaseTypeArgumentIdentifierName(
        Compilation compilation,
        BaseTypeDeclarationSyntax classDeclaration
    )
    {
        var baseType =
            classDeclaration
                .BaseList?
                .Types
                .First()
                .Type as GenericNameSyntax;

        var argumentType =
            baseType!
                .TypeArgumentList
                .Arguments
                .First();

        var identifierNameSyntax =
            argumentType as IdentifierNameSyntax;

        var typeName =
            identifierNameSyntax!
                .Identifier
                .Text;

        var namespaceName =
            GetTypeNamespaceByShortName(
                compilation,
                typeName
            );

        return
            (typeName, namespaceName);
    }

    private static string GetTypeNamespaceByShortName(
        Compilation compilation,
        string shortTypeName
    )
    {
        var compilationReferences =
            compilation.References;

        var assemblyOrModuleSymbol =
            compilation.GetAssemblyOrModuleSymbol;

        var referencedAssemblies =
            compilationReferences
                .Select(
                    assemblyOrModuleSymbol
                )
                .OfType<IAssemblySymbol>();

        foreach (var assemblySymbol in referencedAssemblies)
        {
            var assemblySymbolGlobalNamespace =
                assemblySymbol.GlobalNamespace;

            var namespaceName =
                SearchNamespaceForType(
                    assemblySymbolGlobalNamespace,
                    shortTypeName
                );

            var isNotEmpty =
                !string
                    .IsNullOrEmpty(
                        namespaceName
                    );

            if (isNotEmpty)
            {
                return
                    namespaceName;
            }
        }

        return string.Empty;
    }

    private static string SearchNamespaceForType(
        INamespaceSymbol namespaceSymbol,
        string shortTypeName
    )
    {
        var typeSymbol =
            namespaceSymbol
                .GetTypeMembers(
                    shortTypeName
                )
                .FirstOrDefault();

        if (typeSymbol != null)
        {
            var searchNamespaceForType =
                namespaceSymbol.ToDisplayString();

            return
                searchNamespaceForType;
        }

        var namespaceMembers =
            namespaceSymbol.GetNamespaceMembers();

        foreach (var childNamespace in namespaceMembers)
        {
            var result =
                SearchNamespaceForType(
                    childNamespace,
                    shortTypeName
                );

            var isNotEmpty =
                !string
                    .IsNullOrEmpty(
                        result
                    );

            if (isNotEmpty)
            {
                return
                    result;
            }
        }

        return string.Empty;
    }

    private static void GenerateCode(
        SourceProductionContext context,
        Compilation compilation,
        ImmutableArray<ClassDeclarationSyntax> classDeclarations
    )
    {
        var namespaceListBuilder =
            new StringBuilder();

        var referenceListBuilder =
            new StringBuilder();

        var referenceItemList =
            new List<string>();

        foreach (var classDeclarationSyntax in classDeclarations)
        {
            var syntaxTree =
                classDeclarationSyntax.SyntaxTree;

            var semanticModel =
                compilation
                    .GetSemanticModel(
                        syntaxTree
                    );

            var declaredSymbol =
                semanticModel
                    .GetDeclaredSymbol(
                        classDeclarationSyntax
                    );

            if (declaredSymbol is not INamedTypeSymbol classSymbol)
            {
                continue;
            }

            (
                var typeName,
                var typeNamespace
            ) =
                GetFirstBaseTypeArgumentIdentifierName(
                    compilation,
                    classDeclarationSyntax
                );

            var isNorContainTypeNamespace =
                !referenceItemList
                    .Contains(
                        typeNamespace
                    );

            if (isNorContainTypeNamespace)
            {
                var namespaceListItemTemplate =
                    GetNamespaceListItemTemplate(
                        typeNamespace
                    );

                namespaceListBuilder
                    .AppendLine(
                        namespaceListItemTemplate
                    );

                referenceItemList
                    .Add(
                        namespaceListItemTemplate
                    );
            }

            var validatorName =
                classDeclarationSyntax
                    .Identifier
                    .Text;

            var referenceListItemTemplate =
                GetReferenceListItemTemplate(
                    typeName,
                    validatorName
                );

            referenceListBuilder
                .AppendLine(
                    referenceListItemTemplate
                );

            var validatorNamespace =
                classSymbol
                    .ContainingNamespace
                    .ToDisplayString();

            var isNorContainValidatorNamespace =
                !referenceItemList
                    .Contains(
                        validatorNamespace
                    );

            if (isNorContainValidatorNamespace)
            {
                var namespaceListItemTemplate =
                    GetNamespaceListItemTemplate(
                        validatorNamespace
                    );

                namespaceListBuilder
                    .AppendLine(
                        namespaceListItemTemplate
                    );

                referenceItemList
                    .Add(
                        namespaceListItemTemplate
                    );
            }
        }

        var referenceList =
            referenceListBuilder.ToString();

        var namespaceList =
            namespaceListBuilder.ToString();

        var compilationAssemblyName =
            compilation.AssemblyName;

        var code =
            GetCode(
                namespaceList,
                compilationAssemblyName,
                referenceList
            );

        var sourceText =
            SourceText
                .From(
                    code,
                    Encoding.UTF8
                );

        context
            .AddSource(
                FileName,
                sourceText
            );
    }

    private static string GetCode(
        string namespaceList,
        string? compilationAssemblyName,
        string referenceList
    ) =>
        $$"""
          // <auto-generated/>
          using System.Collections.Generic;

          using Arc.Infrastructure.Common.Interfaces;
          using Arc.Infrastructure.Common.Models.Dependencies;

          {{
              namespaceList
          }}

          using FluentValidation;

          namespace {{
              compilationAssemblyName
          }};

          public sealed class DependencyManager :
              IDependencyManager
          {
              public IReadOnlyList<DependencyBase> GetDependencies()
              {
                  ValidatorOptions
                          .Global
                          .DefaultClassLevelCascadeMode =
                      CascadeMode.Stop;
          
                  ValidatorOptions
                          .Global
                          .DefaultRuleLevelCascadeMode =
                      CascadeMode.Stop;
          
                  return new SingletonDependency[]
                  {
                      {{
                          referenceList
                      }}
                  };
              }
          }
          """;

    private static string GetReferenceListItemTemplate(
        string typeName,
        string validatorName
    ) =>
        $"""
         (
         	typeof(IValidator<{
                 typeName
             }>),
         	typeof({
                 validatorName
             })
         ),
         """;

    private static string GetNamespaceListItemTemplate(
        string validatorNamespace
    ) =>
        $"using {validatorNamespace};";
}