using System;
using System.Collections.Generic;

namespace Arc.Dependencies.FluentValidation.Implementations.Base;

internal sealed class ListItemValueRangeValidator<T> :
    AbstractValidator<IEnumerable<T>>
    where T : IComparable<T>, IComparable
{
    public ListItemValueRangeValidator(
        T from,
        T to
    )
    {
        RuleForEach(
                entity =>
                    entity
            )
            .InclusiveBetween(
                from,
                to
            )
            .WithMessage(
                "{PropertyName} items must be from {From} to {To}."
            );
    }
}