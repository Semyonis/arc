using Arc.Infrastructure.Common.Models;

namespace Arc.Platform.Base.Factories.Containers;

public interface IDependencyContainer
{
    public Type GetImplementationType(
        Type interfaceType
    );

    public ResultContainer<object> GetImplementationInstance(
        Type interfaceType
    );

    public void SetImplementationInstance(
        Type interfaceType,
        object implementationType
    );
}