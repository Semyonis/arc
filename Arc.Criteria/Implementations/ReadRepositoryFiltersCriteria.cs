using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.Implementations.Base;
using Arc.Infrastructure.Common.Enums;

namespace Arc.Criteria.Implementations;

public sealed class ReadRepositoryFiltersCriteria<TEntity> :
    CriteriaBase<TEntity>
    where TEntity : class
{
    public IReadOnlyList<FilterParameterBase<TEntity>>? Filters { get; init; }

    public OperationType OperationType { get; init; }

    protected override Expression<Func<TEntity, bool>> GetPredicate()
    {
        var predicate =
            base.GetPredicate();

        if (Filters.IsEmpty())
        {
            return predicate;
        }

        var isAndOperation =
            OperationType
            == OperationType.And;

        Func
        <
            Expression<Func<TEntity, bool>>,
            Expression<Func<TEntity, bool>>,
            Expression<Func<TEntity, bool>>
        > operation =
            isAndOperation
                ? PredicateBuilder.And
                : PredicateBuilder.Or;

        foreach (var filter in Filters)
        {
            var expression =
                filter.GetPredicate();

            predicate =
                operation(
                    predicate,
                    expression
                );
        }

        return predicate;
    }
}