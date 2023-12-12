using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;
using Arc.Validators.Common.Implementations;

namespace Arc.Validators.Admins.Tables.Implementations.ComplexProperties;

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