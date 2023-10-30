using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Infrastructure.Services.Implementations;

[SuppressMessage(
    "ReSharper",
    "PossibleMultipleEnumeration"
)]
public sealed class PaginationService :
    IPaginationService
{
    public IEnumerable<TEntity> PaginateEnumerable<TEntity>(
        IEnumerable<TEntity> results,
        int currentPage,
        int countPerPage
    )
    {
        if (results.IsEmpty())
        {
            return
                new List<TEntity>();
        }

        if (currentPage < 1
            && countPerPage < 1)
        {
            return results;
        }

        var skipCount =
            (currentPage - 1)
            * countPerPage;

        return
            results
                .Skip(
                    skipCount
                )
                .Take(
                    countPerPage
                );
    }
}