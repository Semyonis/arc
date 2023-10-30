using Arc.Models.Views.Anonymous.Models;

namespace Arc.Dependencies.RequestValidators.Implementations;

public sealed class LoginRequestValidation :
    AbstractValidator<LoginRequest>
{
    public LoginRequestValidation()
    {
        RuleFor(
                entity =>
                    entity.UserName
            )
            .NotEmpty()
            .Length(
                2,
                100
            );

        RuleFor(
                entity =>
                    entity.Password
            )
            .NotEmpty()
            .Length(
                6,
                100
            );
    }
}