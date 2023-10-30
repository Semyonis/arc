using Arc.Infrastructure.Common.Models;
using Arc.Infrastructure.Common.Models.Dependencies;

namespace Arc.Tests.Base.Factories.Containers;

public sealed class DependencyContainer :
    IDependencyContainer
{
    private readonly IDictionary<Type, object>
        _implementationInstanceDictionary;

    private readonly IDictionary<Type, Type>
        _implementationTypeDictionary;

    public DependencyContainer(
        IEnumerable<DependencyBase>
            typeDependencies,
        IEnumerable<KeyValuePair<Type, object>>
            instanceDependencies
    )
    {
        _implementationTypeDictionary =
            typeDependencies
                .ToDictionary(
                    entity =>
                        entity.Interface,
                    entity =>
                        entity.Implementation
                );

        _implementationInstanceDictionary =
            instanceDependencies
                .ToDictionary(
                    entity =>
                        entity.Key,
                    entity =>
                        entity.Value
                );
    }

    public ResultContainer<object> GetImplementationInstance(
        Type interfaceType
    )
    {
        var isExist =
            _implementationInstanceDictionary
                .ContainsKey(
                    interfaceType
                );

        if (isExist)
        {
            var scopeInstance =
                _implementationInstanceDictionary[interfaceType];

            return
                ResultContainer<object>
                    .GetSuccessful(
                        scopeInstance
                    );
        }

        return
            ResultContainer<object>
                .GetFailed();
    }

    public Type GetImplementationType(
        Type interfaceType
    ) =>
        _implementationTypeDictionary[interfaceType];

    public void SetImplementationInstance(
        Type interfaceType,
        object implementationType
    ) =>
        _implementationInstanceDictionary
            .Add(
                interfaceType,
                implementationType
            );
}