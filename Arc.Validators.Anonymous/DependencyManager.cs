using System.Collections.Generic;

using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Models.Views.Anonymous.Models;
using Arc.Validators.Anonymous.Implementations;

namespace Arc.Validators.Anonymous;

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
                typeof(IValidator<ConfirmEmailRequest>),
                typeof(ConfirmEmailRequestValidator)
            ),
            (
                typeof(IValidator<CreateUserRequest>),
                typeof(RegisterRequestValidator)
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
        };
    }
}