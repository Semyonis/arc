using System.Collections.Generic;

using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;
using Arc.Models.Views.Admins.Tables.Models.Groups;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;
using Arc.Validators.Admins.Tables.Implementations.ComplexProperties;
using Arc.Validators.Admins.Tables.Implementations.Groups;
using Arc.Validators.Admins.Tables.Implementations.SimpleProperties;

namespace Arc.Validators.Admins.Tables;

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
                typeof(IValidator<SimplePropertyTableCreateRequest>),
                typeof(SimplePropertyTableCreateRequestValidator)
            ),
            (
                typeof(IValidator<SimplePropertyTableUpdateRequest>),
                typeof(SimplePropertyTableUpdateRequestValidator)
            ),
            (
                typeof(IValidator<GroupTableCreateRequest>),
                typeof(GroupsTableCreateValidator)
            ),
            (
                typeof(IValidator<GroupTableUpdateRequest>),
                typeof(GroupsTableUpdateValidator)
            ),
            (
                typeof(IValidator<ComplexPropertyCreateRequest>),
                typeof(ComplexPropertyCreateRequestValidator)
            ),
            (
                typeof(IValidator<ComplexPropertyUpdateRequest>),
                typeof(ComplexPropertyUpdateRequestValidator)
            ),
        };
    }
}