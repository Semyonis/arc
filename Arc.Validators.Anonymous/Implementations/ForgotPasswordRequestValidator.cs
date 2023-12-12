using Arc.Models.Views.Anonymous.Models;

namespace Arc.Validators.Anonymous.Implementations;

public sealed class ForgotPasswordRequestValidator :
    AbstractValidator<ForgotPasswordRequest>
{
    public ForgotPasswordRequestValidator()
    {
        RuleFor(
                entity =>
                    entity.Email
            )
            .NotEmpty()
            .EmailAddress();

        RuleFor(
                entity =>
                    entity.Url
            )
            .NotEmpty();
    }
}