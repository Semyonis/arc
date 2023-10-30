using System.Collections.Generic;

namespace Arc.Infrastructure.Services.Interfaces;

public interface IPaginationService
{
    IEnumerable<TEntity> PaginateEnumerable<TEntity>(
        IEnumerable<TEntity> results,
        int currentPage,
        int countPerPage
    );
}