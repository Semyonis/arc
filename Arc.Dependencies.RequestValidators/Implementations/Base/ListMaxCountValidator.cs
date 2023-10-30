using System.Collections.Generic;
using System.Linq;

namespace Arc.Dependencies.RequestValidators.Implementations.Base;

internal sealed class ListMaxCountValidator<T> :
    AbstractValidator<IEnumerable<T>>
{
    public ListMaxCountValidator(
        string propertyName,
        int countThreshold
    )
    {
        RuleFor(
                entity =>
                    entity
            )
            .Must(
                entity =>
                    entity.Count() <= countThreshold
            )
            .WithMessage(
                $"Count of {propertyName} must be less or equal to {countThreshold.ToString()}."
            );
    }
}