using Arc.Infrastructure.Common.Enums;

namespace Arc.Infrastructure.Common.Models.Dependencies;

public sealed record SingletonDependency :
    DependencyBase
{
    public SingletonDependency(
        Type @interface,
        Type implementation
    ) : base(
        @interface,
        implementation,
        LifeTimeType.Singleton
    ) { }

    public static implicit operator SingletonDependency(
        (Type iterface, Type implementation) pair
    ) =>
        new(
            pair.iterface,
            pair.implementation
        );
}