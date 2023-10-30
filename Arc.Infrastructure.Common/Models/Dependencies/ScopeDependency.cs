using Arc.Infrastructure.Common.Enums;

namespace Arc.Infrastructure.Common.Models.Dependencies;

public sealed record ScopeDependency :
    DependencyBase
{
    public ScopeDependency(
        Type @interface,
        Type implementation
    ) : base(
        @interface,
        implementation,
        LifeTimeType.Scoped
    ) { }

    public static implicit operator ScopeDependency(
        (Type iterface, Type implementation) pair
    ) =>
        new(
            pair.iterface,
            pair.implementation
        );
}