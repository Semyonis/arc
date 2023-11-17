using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Models;
using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Infrastructure.Services.Implementations;

[SuppressMessage(
    "ReSharper",
    "PossibleMultipleEnumeration"
)]
public sealed class PaginationService :
    IPaginationService
{
    public ResultContainer<IEnumerable<TEntity>> Paginate<TEntity>(
        IEnumerable<TEntity> results,
        int currentPage,
        int countPerPage
    )
    {
        if (results.IsEmpty())
        {
            return
                ResultContainer<IEnumerable<TEntity>>
                    .Successful(
                        new List<TEntity>()
                    );
        }

        if (currentPage < 1
            && countPerPage < 1)
        {
            return
                ResultContainer<IEnumerable<TEntity>>.Failed();
        }

        var skipCount =
            (currentPage - 1)
            * countPerPage;

        var paginatedResults =
            results
                .Skip(
                    skipCount
                )
                .Take(
                    countPerPage
                );

        return
            ResultContainer<IEnumerable<TEntity>>
                .Successful(
                    paginatedResults
                );
    }
}