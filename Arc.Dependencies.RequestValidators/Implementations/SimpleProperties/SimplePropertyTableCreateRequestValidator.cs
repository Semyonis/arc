using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Dependencies.RequestValidators.Implementations.SimpleProperties;

public sealed class SimplePropertyTableCreateRequestValidator :
    AbstractValidator<SimplePropertyTableCreateRequest>
{
    public SimplePropertyTableCreateRequestValidator()
    {
        RuleForEach(
                entity =>
                    entity.Items
            )
            .SetValidator(
                new SimplePropertyCreateValidator()
            );
    }
}