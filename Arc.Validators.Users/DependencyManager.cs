using System.Collections.Generic;

using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Models.Views.Users.Models;
using Arc.Validators.Users.Implementations;

namespace Arc.Validators.Users;

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
                typeof(IValidator<ChangePasswordRequest>),
                typeof(ChangePasswordRequestValidator)
            ),
        };
    }
}