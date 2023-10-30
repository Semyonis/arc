using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Dependencies.RequestValidators.Implementations.SimpleProperties;

public sealed class SimplePropertyTableUpdateRequestValidator :
    AbstractValidator<SimplePropertyTableUpdateRequest>
{
    public SimplePropertyTableUpdateRequestValidator()
    {
        RuleForEach(
                entity =>
                    entity.Items
            )
            .SetValidator(
                new SimplePropertyUpdateValidator()
            );

        RuleForEach(
                entity =>
                    entity.Items
            )
            .Must(
                entity =>
                    entity.Id > 0
            )
            .WithMessage(
                "Id must be greater than 0."
            );
    }
}