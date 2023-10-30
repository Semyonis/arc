using Arc.Infrastructure.Common.Enums;

namespace Arc.Infrastructure.Common.Models.Dependencies;

public abstract record DependencyBase(
    Type Interface,
    Type Implementation,
    LifeTimeType LifeTimeType
);