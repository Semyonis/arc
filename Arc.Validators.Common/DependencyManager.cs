using System.Collections.Generic;

using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Models.Views.Common.Models;
using Arc.Validators.Common.Implementations;

namespace Arc.Validators.Common;

public sealed class DependencyManager :
    IDependencyManager
{
    public IReadOnlyList<DependencyBase> GetDependencies()
    {
        ValidatorOptions
                .Global
                .DefaultClassLevelCascadeMode =
            CascadeMode.Stop;

        ValidatorOptions
                .Global
                .DefaultRuleLevelCascadeMode =
            CascadeMode.Stop;

        return new SingletonDependency[]
        {
            (
                typeof(IValidator<UserResponse>),
                typeof(UserResponseValidator)
            ),
            (
                typeof(IValidator<ReferenceRequest>),
                typeof(ReferenceRequestValidator)
            ),
        };
    }
}