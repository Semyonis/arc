using System.Collections.Generic;

using Arc.Infrastructure.Common.Models;

namespace Arc.Infrastructure.Services.Interfaces;

public interface IPaginationService
{
    ResultContainer<IEnumerable<TEntity>> Paginate<TEntity>(
        IEnumerable<TEntity> results,
        int currentPage,
        int countPerPage
    );
}