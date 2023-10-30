using Arc.Models.Views.Admins.Models;

namespace Arc.Dependencies.RequestValidators.Implementations;

public sealed class ChangePasswordAdminRequestValidator :
    AbstractValidator<ChangePasswordAdminRequest>
{
    public ChangePasswordAdminRequestValidator()
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
            );
    }
}