using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;
using Arc.Validators.Common.Implementations;

namespace Arc.Validators.Admins.Tables.Implementations.ComplexProperties;

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