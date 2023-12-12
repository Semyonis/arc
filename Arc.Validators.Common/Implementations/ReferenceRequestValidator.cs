using Arc.Models.Views.Common.Models;

namespace Arc.Validators.Common.Implementations;

public sealed class ReferenceRequestValidator :
    AbstractValidator<ReferenceRequest>
{
    public ReferenceRequestValidator()
    {
        RuleFor(
                entity =>
                    entity.Id
            )
            .GreaterThan(
                0
            );
    }
}