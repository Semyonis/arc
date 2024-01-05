using System.Collections.Generic;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;

namespace Arc.Dependencies.RedisStack;

public sealed class DependencyManager :
    IDependencyManager
{
    public IReadOnlyList<DependencyBase> GetDependencies() =>
        typeof(DependencyManager).GetSingletonDependencies();
}