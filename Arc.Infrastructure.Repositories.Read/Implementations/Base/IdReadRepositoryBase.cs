using System.Linq.Expressions;

using Arc.Criteria.Implementations;
using Arc.Database.Context;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces.Base;

namespace Arc.Infrastructure.Repositories.Read.Implementations.Base;

public abstract class IdReadRepositoryBase
<
    TEntity
>(
    ArcDatabaseContext context
) :
    ReadRepositoryBase<TEntity>(
        context
    ),
    IReadRepositoryBase<TEntity>
    where TEntity : class, IWithIdentifier
{
    public async Task<TEntity?> GetById(
        int entityId,
        Func
            <
                IQueryable<TEntity>,
                IIncludableQueryable<TEntity, object>
            >?
            include = default,
        bool asNoTracking = true
    )
    {
        var criteria =
            new ReadRepositoryEntityIdsCriteria<TEntity>
            {
                Ids = entityId
                    .WrapByList(),
            };

        return
            await
                GetFirstByCriteriaAsync(
                    criteria,
                    include,
                    asNoTracking
                );
    }

    public async Task<IReadOnlyList<TEntity>> GetByIds(
        IReadOnlyList<int> ids,
        Func
            <
                IQueryable<TEntity>,
                IIncludableQueryable<TEntity, object>
            >?
            include = default,
        bool asNoTracking = true
    )
    {
        var criteria =
            new ReadRepositoryEntityIdsCriteria<TEntity>
            {
                Ids = ids,
            };

        return
            await
                GetListByCriteriaAsync(
                    criteria,
                    include,
                    asNoTracking
                );
    }

    protected async Task<TProjection?> GetProjectionById<TProjection>(
        int entityId,
        Expression<Func<TEntity, TProjection>> projection
    )
    {
        var criteria =
            new ReadRepositoryEntityIdsCriteria<TEntity>
            {
                Ids = entityId
                    .WrapByReadOnlyList(),
            };

        return
            await
                GetProjectionByCriteriaAsync(
                    criteria,
                    projection
                );
    }
}