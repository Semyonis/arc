using Arc.Models.Views.Users.Models;

namespace Arc.Validators.Users.Implementations;

public sealed class ChangePasswordRequestValidator :
    AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(
                entity =>
                    entity.CurrentPassword
            )
            .NotEmpty()
            .Length(
                6,
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

        RuleFor(
                entity =>
                    entity.PasswordConfirm
            )
            .NotEmpty()
            .Equal(
                entity =>
                    entity.Password
            );
    }
}