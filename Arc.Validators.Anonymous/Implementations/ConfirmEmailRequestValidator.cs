using Arc.Models.Views.Anonymous.Models;

namespace Arc.Validators.Anonymous.Implementations;

public sealed class ConfirmEmailRequestValidator :
    AbstractValidator<ConfirmEmailRequest>
{
    public ConfirmEmailRequestValidator()
    {
        RuleFor(
                entity =>
                    entity.UserId
            )
            .NotEmpty();

        RuleFor(
                entity =>
                    entity.Code
            )
            .NotEmpty();
    }
}