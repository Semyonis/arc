﻿using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;

namespace Arc.Infrastructure.Repositories.Read;

public sealed class DependencyManager :
    IDependencyManager
{
    public IReadOnlyList<DependencyBase> GetDependencies() =>
        typeof(DependencyManager).GetScopedDependencies();
}