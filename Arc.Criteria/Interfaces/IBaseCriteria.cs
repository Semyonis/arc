using Arc.Infrastructure.Common.Models;
using Arc.Database.Entities;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Criteria.Interfaces;

public interface IBaseCriteria<TEntity>
    where TEntity : class
{
    IQueryable<TEntity> CropResults(
        IQueryable<TEntity> entities
    );

    void SetInclude(
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include
    );

    void SetAsNoTracking(
        bool asNoTracking = true
    );

    void SetPagination(
        PaginationIn pagination
    );

    void SetOrdering(
        params OrderingParam<TEntity>[]? orderingParams
    );
}