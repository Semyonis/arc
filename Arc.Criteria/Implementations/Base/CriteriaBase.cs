using Arc.Criteria.Interfaces;
using Arc.Infrastructure.Common.Models;
using Arc.Models.DataBase;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using static Arc.Infrastructure.Common.Enums.OrderingType;

namespace Arc.Criteria.Implementations.Base;

public abstract class CriteriaBase<TEntity> :
    IBaseCriteria<TEntity>
    where TEntity : class
{
    private bool
        _asNoTracking;

    private Func
    <
        IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>
    >? _includes;

    private IReadOnlyList<OrderingParam<TEntity>>?
        _orderingParams;

    private PaginationIn?
        _pagination;

    public virtual IQueryable<TEntity> CropResults(
        IQueryable<TEntity> entities
    )
    {
        var predicate =
            GetPredicate();

        var results =
            entities
                .Where(
                    predicate.Expand()
                );

        results =
            OrderQuery(
                results
            );

        results =
            PaginateQuery(
                results
            );

        if (_includes != default)
        {
            results =
                _includes(
                    results
                );
        }

        if (_asNoTracking)
        {
            results =
                results.AsNoTracking();
        }

        return results;
    }

    public void SetInclude(
        Func
        <
            IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>
        >? include
    ) =>
        _includes =
            include;

    public void SetAsNoTracking(
        bool asNoTracking = true
    ) =>
        _asNoTracking =
            asNoTracking;

    public void SetPagination(
        PaginationIn pagination
    ) =>
        _pagination =
            pagination;

    public void SetOrdering(
        params OrderingParam<TEntity>[]? orderingParams
    ) =>
        _orderingParams =
            orderingParams;

    protected virtual Expression<Func<TEntity, bool>> GetPredicate() =>
        PredicateBuilder
            .New<TEntity>()
            .Start(
                entity =>
                    true
            );

    private IQueryable<TEntity> PaginateQuery(
        IQueryable<TEntity> results
    )
    {
        if (_pagination == default)
        {
            return results;
        }

        var currentPageIsLessThenOne =
            _pagination.CurrentPage < 1;

        var countPerPageIsLessThenOne =
            _pagination.CountPerPage < 1;

        var isWrongSettings =
            currentPageIsLessThenOne
            && countPerPageIsLessThenOne;

        if (isWrongSettings)
        {
            return results;
        }

        var skippedPages =
            _pagination.CurrentPage - 1;

        var skipResultCount =
            skippedPages
            * _pagination.CountPerPage;

        return
            results
                .Skip(
                    skipResultCount
                )
                .Take(
                    _pagination.CountPerPage
                );
    }

    private IQueryable<TEntity> OrderQuery(
        IQueryable<TEntity> results
    )
    {
        if (_orderingParams.IsEmpty())
        {
            return results;
        }

        var firstParam =
            _orderingParams[0];

        var isDescending =
            firstParam.OrderingType
            == Descending;

        var keySelector =
            firstParam
                .Expression
                .Expand();

        var orderedResult =
            isDescending
                ? results
                    .OrderByDescending(
                        keySelector
                    )
                : results
                    .OrderBy(
                        keySelector
                    );

        var orderingExpressions =
            _orderingParams
                .Skip(
                    1
                );

        foreach (var param in orderingExpressions)
        {
            var isDescendingType =
                param.OrderingType
                == Descending;

            var expression =
                param
                    .Expression
                    .Expand();

            orderedResult =
                isDescendingType
                    ? orderedResult
                        .ThenByDescending(
                            expression
                        )
                    : orderedResult
                        .ThenBy(
                            expression
                        );
        }

        return orderedResult;
    }
}