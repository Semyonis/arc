using Arc.Infrastructure.Common.Models.Dependencies;

namespace Arc.Infrastructure.Common.Interfaces;

public interface IDependencyManager
{
    IReadOnlyList<DependencyBase> GetDependencies();
}