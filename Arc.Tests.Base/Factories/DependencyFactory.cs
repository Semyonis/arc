using System.Reflection;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Tests.Base.Factories.Containers;

namespace Arc.Tests.Base.Factories;

public sealed class DependencyFactory(
    IDependencyContainer
        dependencyContainer,
    IMultipleConstructorsExceptionDescriptor
        multipleConstructorsExceptionDescriptor,
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor
)
{
    public TInterface GetImplementation<TInterface>() =>
        (TInterface)GetInstance(
            typeof(TInterface)
        );

    private object GetInstance(
        Type interfaceType
    )
    {
        var resultContainer =
            dependencyContainer
                .GetImplementationInstance(
                    interfaceType
                );

        if (resultContainer.IsSuccess)
        {
            return
                resultContainer.Value;
        }

        var implementationType =
            GetImplementationType(
                interfaceType
            );

        return
            CreateInstance(
                implementationType
            );
    }

    private object CreateInstance(
        Type implementationType
    )
    {
        var constructor =
            GetConstructor(
                implementationType
            );

        var constructorParameters =
            constructor.GetParameters();

        var args =
            GetInstanceArgs(
                constructorParameters
            );

        return
            Activator
                .CreateInstance(
                    implementationType,
                    args
                )!;
    }

    private object[] GetInstanceArgs(
        ParameterInfo[] parameters
    )
    {
        if (parameters.IsEmpty())
        {
            return
                Array.Empty<object>();
        }

        var result =
            new List<object>();

        foreach (var parameterInfo in parameters)
        {
            var parameterObject =
                GetInstance(
                    parameterInfo.ParameterType
                );

            result
                .Add(
                    parameterObject
                );
        }

        return
            result.ToArray();
    }

    private ConstructorInfo GetConstructor(
        Type implementationType
    )
    {
        var constructors =
            implementationType
                .GetConstructors(
                    BindingFlags.Instance
                    | BindingFlags.Public
                );

        if (constructors.IsEmpty())
        {
            throw
                badDataExceptionDescriptor.CreateException();
        }

        if (constructors.Length == 1)
        {
            return constructors[0];
        }

        throw
            multipleConstructorsExceptionDescriptor
                .CreateException();
    }

    private Type GetImplementationType(
        Type type
    )
    {
        var isNotInterface =
            !type.IsInterface;

        if (isNotInterface)
        {
            return type;
        }

        return
            dependencyContainer
                .GetImplementationType(
                    type
                );
    }

    public void SetImplementation(
        Type interfaceType,
        object implementationType
    )
    {
        dependencyContainer
            .SetImplementationInstance(
                interfaceType,
                implementationType
            );
    }
}