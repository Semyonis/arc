using Arc.Criteria.Implementations.Base;
using Arc.Infrastructure.Common.Interfaces;

namespace Arc.Criteria.Implementations;

public sealed class ReadRepositoryEntityIdsCriteria<TEntity> :
    CriteriaBase<TEntity>
    where TEntity : class, IWithIdentifier
{
    public IReadOnlyList<int>? Ids { get; init; }

    protected override Expression<Func<TEntity, bool>> GetPredicate()
    {
        var predicate =
            base.GetPredicate();

        if (Ids.IsNotEmpty())
        {
            predicate =
                predicate
                    .And(
                        entity =>
                            Ids
                                .Contains(
                                    entity.Id
                                )
                    );
        }

        return predicate;
    }
}