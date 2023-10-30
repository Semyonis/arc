using Arc.Dependencies.RequestValidators.Implementations.Groups;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Dependencies.RequestValidators.Implementations.ComplexProperties;

public sealed class ComplexPropertyUpdateRequestValidator :
    AbstractValidator<ComplexPropertyUpdateRequest>
{
    public ComplexPropertyUpdateRequestValidator()
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
                    entity.Name
            )
            .NotEmpty();

        RuleFor(
                entity =>
                    entity.Group
            )
            .SetValidator(
                new ReferenceRequestValidator()
            );
    }
}