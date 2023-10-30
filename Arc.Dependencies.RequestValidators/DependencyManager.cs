using System.Collections.Generic;

using Arc.Dependencies.RequestValidators.Implementations;
using Arc.Dependencies.RequestValidators.Implementations.ComplexProperties;
using Arc.Dependencies.RequestValidators.Implementations.Groups;
using Arc.Dependencies.RequestValidators.Implementations.SimpleProperties;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Models.Views.Admins.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;
using Arc.Models.Views.Admins.Tables.Models.Groups;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;
using Arc.Models.Views.Anonymous.Models;
using Arc.Models.Views.Common.Models;
using Arc.Models.Views.Users.Models;

using UserResponse = Arc.Models.Views.Common.Models.UserResponse;

namespace Arc.Dependencies.RequestValidators;

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
                typeof(IValidator<UserResponse>),
                typeof(UserResponseValidator)
            ),
            (
                typeof(IValidator<ConfirmEmailRequest>),
                typeof(ConfirmEmailRequestValidator)
            ),
            (
                typeof(IValidator<CreateUserRequest>),
                typeof(RegisterRequestValidator)
            ),
            (
                typeof(IValidator<ChangePasswordRequest>),
                typeof(ChangePasswordRequestValidator)
            ),
            (
                typeof(IValidator<ResetPasswordRequest>),
                typeof(ResetPasswordRequestValidator)
            ),
            (
                typeof(IValidator<ForgotPasswordRequest>),
                typeof(ForgotPasswordRequestValidator)
            ),
            (
                typeof(IValidator<LoginRequest>),
                typeof(LoginRequestValidation)
            ),
            (
                typeof(IValidator<RefreshTokenRequest>),
                typeof(RefreshTokenRequestValidation)
            ),
            (
                typeof(IValidator<ChangePasswordAdminRequest>),
                typeof(ChangePasswordAdminRequestValidator)
            ),
            (
                typeof(IValidator<ComplexPropertyCreateRequest>),
                typeof(ComplexPropertyCreateRequestValidator)
            ),
            (
                typeof(IValidator<ReferenceRequest>),
                typeof(ReferenceRequestValidator)
            ),
            (
                typeof(IValidator<ComplexPropertyUpdateRequest>),
                typeof(ComplexPropertyUpdateRequestValidator)
            ),
        };
    }
}