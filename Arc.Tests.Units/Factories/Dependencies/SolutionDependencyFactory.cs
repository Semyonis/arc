using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Infrastructure.Services;

namespace Arc.Tests.Units.Factories.Dependencies;

public static class SolutionDependencyFactory
{
    public static IEnumerable<DependencyBase> GetDependencyItems() =>
        new IDependencyManager[]
            {
                new DependencyManager(),
            }
            .SelectMany(
                manager =>
                    manager.GetDependencies()
            );
}