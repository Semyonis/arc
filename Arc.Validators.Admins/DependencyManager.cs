using System.Collections.Generic;

using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Models.Views.Admins.Models;
using Arc.Validators.Admins.Implementations;

namespace Arc.Validators.Admins;

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
                typeof(IValidator<ChangePasswordAdminRequest>),
                typeof(ChangePasswordAdminRequestValidator)
            ),
        };
    }
}