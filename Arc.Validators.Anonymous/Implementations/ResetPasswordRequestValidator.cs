using Arc.Models.Views.Anonymous.Models;

namespace Arc.Validators.Anonymous.Implementations;

public sealed class ResetPasswordRequestValidator :
    AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordRequestValidator()
    {
        RuleFor(
                entity =>
                    entity.Email
            )
            .NotEmpty()
            .EmailAddress();

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
            )
            .WithMessage(
                "'Password Confirm' must be equal to field 'Password'"
            );

        RuleFor(
                entity =>
                    entity.PasswordConfirm
            )
            .NotEmpty()
            .Length(
                6,
                100
            );

        RuleFor(
                entity =>
                    entity.Code
            )
            .NotEmpty();
    }
}