using System;
using System.Collections.Generic;

namespace Arc.Dependencies.FluentValidation.Implementations.Base;

internal sealed class ListValidator<T> :
    AbstractValidator<IEnumerable<T>>
    where T : IComparable<T>, IComparable
{
    public ListValidator(
        string propertyName,
        int maxCount,
        T from,
        T to
    )
    {
        Include(
            new ListMaxCountValidator<T>(
                propertyName,
                maxCount
            )
        );

        Include(
            new ListItemValueRangeValidator<T>(
                from,
                to
            )
        );
    }
}