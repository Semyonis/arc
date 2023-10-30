using Arc.Models.Views.Common.Models;

namespace Arc.Dependencies.RequestValidators.Implementations.Groups;

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