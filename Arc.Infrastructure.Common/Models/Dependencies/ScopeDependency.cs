using Arc.Infrastructure.Common.Enums;

namespace Arc.Infrastructure.Common.Models.Dependencies;

public sealed record ScopeDependency(
    Type Interface,
    Type Implementation
) : DependencyBase(
    Interface,
    Implementation,
    LifeTimeType.Scoped
)
{
    public static implicit operator ScopeDependency(
        (Type iterface, Type implementation) pair
    ) =>
        new(
            pair.iterface,
            pair.implementation
        );
}