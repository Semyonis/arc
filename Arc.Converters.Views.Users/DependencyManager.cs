using System.Collections.Generic;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;

namespace Arc.Converters.Views.Users;

public sealed class DependencyManager :
    IDependencyManager
{
    public IReadOnlyList<DependencyBase> GetDependencies() =>
        typeof(DependencyManager).GetSingletonDependencies();
}