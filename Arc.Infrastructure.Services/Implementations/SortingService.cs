using System.Collections.Generic;
using System.Linq;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models;
using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Infrastructure.Services.Implementations;

public sealed class SortingService :
    ISortingService
{
    public ResultContainer<IReadOnlyList<T>> SortByList<T>(
        IReadOnlyList<T> source,
        IReadOnlyList<int> target
    )
        where T : IWithIdentifier
    {
        var isEmptyTarget =
            target.IsEmpty();

        var isEmptySource =
            source.IsEmpty();

        var isDifferentCount =
            target.Count
            != source.Count;

        var isNotEquivalent =
            isEmptyTarget
            || isEmptySource
            || isDifferentCount;

        if (isNotEquivalent)
        {
            return
                ResultContainer<IReadOnlyList<T>>.GetFailed();
        }

        var result =
            target
                .Select(
                    item =>
                        source
                            .First(
                                withIdentifier =>
                                    withIdentifier.Id
                                    == item
                            )
                )
                .ToList();

        return
            ResultContainer<IReadOnlyList<T>>
                .GetSuccessful(
                    result
                );
    }
}