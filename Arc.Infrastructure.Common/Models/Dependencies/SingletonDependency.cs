using Arc.Infrastructure.Common.Enums;

namespace Arc.Infrastructure.Common.Models.Dependencies;

public sealed record SingletonDependency(
        Type Interface,
        Type Implementation
    )
    :
        DependencyBase(
        Interface,
        Implementation,
        LifeTimeType.Singleton
    )
{
    public static implicit operator SingletonDependency(
        (Type iterface, Type implementation) pair
    ) =>
        new(
            pair.iterface,
            pair.implementation
        );
}