using Arc.Models.Views.Anonymous.Models;

namespace Arc.Validators.Anonymous.Implementations;

public sealed class RegisterRequestValidator :
    AbstractValidator<CreateUserRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(
                entity =>
                    entity.FirstName
            )
            .NotEmpty()
            .Length(
                2,
                100
            );

        RuleFor(
                entity =>
                    entity.LastName
            )
            .NotEmpty()
            .Length(
                2,
                100
            );

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
    }
}