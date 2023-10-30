using Arc.Dependencies.RequestValidators.Implementations.Groups;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Dependencies.RequestValidators.Implementations.ComplexProperties;

public sealed class ComplexPropertyCreateRequestValidator :
    AbstractValidator<ComplexPropertyCreateRequest>
{
    public ComplexPropertyCreateRequestValidator()
    {
        RuleFor(
                entity =>
                    entity.Group
            )
            .NotNull()
            .SetValidator(
                new ReferenceRequestValidator()
            );

        RuleFor(
                entity =>
                    entity.Name
            )
            .NotEmpty();
    }
}