using System.Reflection;

using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;

using Microsoft.Extensions.DependencyModel;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class SolutionDependencies
{
    private const string ExpectedAssemblyNameStart =
        "Arc.";

    public static IServiceCollection SetupDependencies(
        this IServiceCollection services
    )
    {
        var assemblyArray =
            GetAssemblyArray();

        var dependencies =
            assemblyArray.GetSolutionDependencies();

        return
            services
                .RegisterDependencies(
                    dependencies
                );
    }

    private static Assembly[] GetAssemblyArray()
    {
        var dependencyAssemblies =
            DependencyContext
                .Default!
                .RuntimeLibraries
                .Where(
                    NameStartWithArc()
                );
        
        var assemblies =
            new List<Assembly>();

        foreach (var dependencyAssembly in dependencyAssemblies)
        {
            var assemblyName =
                new AssemblyName(
                dependencyAssembly.Name
            );

            var assembly =
                Assembly
                    .Load(
                        assemblyName
                    );

            assemblies
                .Add(
                    assembly
                );
        }

        return
            assemblies.ToArray();
    }

    private static Func<RuntimeLibrary, bool> NameStartWithArc() =>
        assembly =>
            assembly
                .Name
                .StartsWith(
                    ExpectedAssemblyNameStart
                );

    private static IReadOnlyList<DependencyBase>[]
        GetSolutionDependencies(
            this Assembly[] assemblyList
        )
    {
        var types =
            assemblyList
                .SelectMany(
                    module =>
                        module.GetTypes()
                );

        var typeList =
            types
                .Where(
                    IsNotAbstractClass
                )
                .Where(
                    IsDerivedFromIDependencyManager
                )
                .ToList();

        var instances =
            new List<IDependencyManager>();

        foreach (var type in typeList)
        {
            var instanceObject =
                Activator
                    .CreateInstance(
                        type
                    );

            var instance =
                (IDependencyManager)
                instanceObject!;

            instances
                .Add(
                    instance
                );
        }

        return
            instances
                .Select(
                    manager =>
                        manager.GetDependencies()
                )
                .ToArray();
    }

    private static bool IsNotAbstractClass(
        Type type
    ) =>
        type is { IsAbstract: false, IsClass: true, };

    private static bool IsDerivedFromIDependencyManager(
        Type type
    )
    {
        var isClass =
            type.IsClass;

        var memberInfo =
            type
            .GetInterface(
                nameof(IDependencyManager)
            );

        var isNotEmpty =
            memberInfo != default;

        return
            isClass
            && isNotEmpty;
    }

    private static IServiceCollection RegisterDependencies(
        this IServiceCollection services,
        params IReadOnlyList<DependencyBase>[] dependenciesArray
    )
    {
        foreach (var dependencies in dependenciesArray)
        {
            foreach (var dependency in dependencies)
            {
                (
                    var @interface,
                    var implementation,
                    var lifeTimeType
                ) = dependency;

                var isScoped =
                    lifeTimeType
                    == LifeTimeType.Scoped;

                var serviceLifetime =
                    isScoped
                        ? ServiceLifetime.Scoped
                        : ServiceLifetime.Singleton;

                var serviceDescriptor =
                    new ServiceDescriptor(
                        @interface,
                        implementation,
                        serviceLifetime
                    );

                services
                    .Add(
                        serviceDescriptor
                    );
            }
        }

        return
            services;
    }
}