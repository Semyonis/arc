using Arc.Models.Views.Common.Models;

namespace Arc.Validators.Common.Implementations;

public sealed class UserResponseValidator :
    AbstractValidator<UserResponse>
{
    public UserResponseValidator()
    {
        RuleFor(
                entity =>
                    entity.Id
            )
            .GreaterThan(
                0
            );

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
    }
}