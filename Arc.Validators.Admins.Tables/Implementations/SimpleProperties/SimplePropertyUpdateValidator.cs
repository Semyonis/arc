using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Validators.Admins.Tables.Implementations.SimpleProperties;

public sealed class SimplePropertyUpdateValidator :
    AbstractValidator<SimplePropertyUpdateRequest>
{
    public SimplePropertyUpdateValidator()
    {
        RuleFor(
                entity =>
                    entity.Value
            )
            .NotEmpty()
            .MaximumLength(
                100
            );
    }
}