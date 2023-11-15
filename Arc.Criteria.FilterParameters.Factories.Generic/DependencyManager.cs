using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;

namespace Arc.Criteria.FilterParameters.Factories.Generic;

public sealed class DependencyManager :
    IDependencyManager
{
    public IReadOnlyList<DependencyBase> GetDependencies() =>
        typeof(DependencyManager)
            .Assembly
            .GetDependencies(
                LifeTimeType.Singleton
            );
}