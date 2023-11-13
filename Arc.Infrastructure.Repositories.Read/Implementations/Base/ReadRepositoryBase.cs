using System.Linq.Expressions;
using System.Threading;

using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.Implementations;
using Arc.Criteria.Interfaces;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Models;
using Arc.Models.DataBase;

using Microsoft.EntityFrameworkCore;

namespace Arc.Infrastructure.Repositories.Read.Implementations.Base;

public abstract class ReadRepositoryBase<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity>
        _entitySet;

    protected ReadRepositoryBase(
        DbContext context
    ) =>
        _entitySet =
            context
                .Set<TEntity>();

    public async Task<int> GetCountByFiltersAsync(
        IReadOnlyList<FilterParameterBase<TEntity>>? filters = default,
        CancellationToken cancellationToken = default
    )
    {
        var criteria =
            new ReadRepositoryFiltersCriteria<TEntity>
            {
                Filters =
                    filters,
            };

        var results =
            CropByCriteria(
                criteria
            );

        return
            await
                results
                    .CountAsync(
                        cancellationToken
                    );
    }

    public async Task<TEntity?> GeFirstByFiltersAsync(
        IReadOnlyList<FilterParameterBase<TEntity>>? filters = default,
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? include = default,
        bool asNoTracking = true,
        PaginationIn? pagination = default,
        OrderingParam<TEntity>? orderingParam = default,
        OperationType operationType = OperationType.And
    )
    {
        var entities =
            await
                GetListByFiltersAsync(
                    filters,
                    include,
                    asNoTracking,
                    orderingParam: orderingParam
                );

        return
            entities.FirstOrDefault();
    }
    

    public async Task<IReadOnlyList<TEntity>> GetListByFiltersAsync(
        IReadOnlyList<FilterParameterBase<TEntity>>? filters = default,
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? include = default,
        bool asNoTracking = true,
        PaginationIn? pagination = default,
        OrderingParam<TEntity>? orderingParam = default,
        OperationType operationType = OperationType.And
    )
    {
        var criteria =
            new ReadRepositoryFiltersCriteria<TEntity>
            {
                Filters =
                    filters,
                OperationType =
                    operationType,
            };

        return await
            GetListByCriteriaAsync(
                criteria,
                include,
                asNoTracking,
                pagination,
                orderingParam
            );
    }

    protected async Task<TEntity?> GetFirstByCriteriaAsync(
        IBaseCriteria<TEntity> criteria,
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? include = default,
        bool asNoTracking = true,
        OrderingParam<TEntity>? orderingParam = default
    )
    {
        var entities =
            await
                GetListByCriteriaAsync(
                    criteria,
                    include,
                    asNoTracking,
                    orderingParam: orderingParam
                );

        return
            entities.FirstOrDefault();
    }

    protected async Task<IReadOnlyList<TEntity>> GetListByCriteriaAsync(
        IBaseCriteria<TEntity> criteria,
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? include = default,
        bool asNoTracking = true,
        PaginationIn? pagination = default,
        OrderingParam<TEntity>? orderingParam = default
    )
    {
        criteria.SetAsNoTracking(
            asNoTracking
        );

        if (orderingParam != default)
        {
            criteria
                .SetOrdering(
                    orderingParam
                );
        }

        if (pagination != default)
        {
            criteria
                .SetPagination(
                    pagination
                );
        }

        if (include != default)
        {
            criteria
                .SetInclude(
                    include
                );
        }

        var results =
            CropByCriteria(
                criteria
            );

        return 
            await
                results.ToListAsync();
    }

    protected async Task<TProjection?>
        GetProjectionByCriteriaAsync<TProjection>(
            IBaseCriteria<TEntity> criteria,
            Expression<Func<TEntity, TProjection>> projection,
            PaginationIn? pagination = default,
            OrderingParam<TEntity>? orderingParam = default
        )
    {
        var entities =
            await
                GetProjectionListByCriteriaAsync(
                    criteria,
                    projection,
                    pagination,
                    orderingParam
                );

        return
            entities.FirstOrDefault();
    }

    protected async Task<IReadOnlyList<TProjection>>
        GetProjectionListByCriteriaAsync<TProjection>(
            IBaseCriteria<TEntity> criteria,
            Expression<Func<TEntity, TProjection>> projection,
            PaginationIn? pagination = default,
            OrderingParam<TEntity>? orderingParam = default
        )
    {
        criteria.SetAsNoTracking();

        if (orderingParam != default)
        {
            criteria
                .SetOrdering(
                    orderingParam
                );
        }

        if (pagination != default)
        {
            criteria
                .SetPagination(
                    pagination
                );
        }

        var results =
            CropByCriteria(
                    criteria
                )
                .Select(
                    projection
                );

        return 
            await
                results
                    .ToListAsync();
    }

    private IQueryable<TEntity> CropByCriteria(
        IBaseCriteria<TEntity>? criteria
    )
    {
        var results =
            _entitySet.AsQueryable();

        if (criteria == default)
        {
            return results;
        }

        return
            criteria
                .CropResults(
                    results
                );
    }
}