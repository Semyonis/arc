using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Dependencies.RequestValidators.Implementations.SimpleProperties;

public sealed class SimplePropertyCreateValidator :
    AbstractValidator<SimplePropertyCreateRequest>
{
    public SimplePropertyCreateValidator()
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