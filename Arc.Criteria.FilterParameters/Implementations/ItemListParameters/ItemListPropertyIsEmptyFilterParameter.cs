using Arc.Criteria.FilterParameters.Implementations.Base;

namespace Arc.Criteria.FilterParameters.Implementations.ItemListParameters;

public sealed class ItemListPropertyIsEmptyFilterParameter<TEntity, TProperty>(
        Expression
            <
                Func<TEntity, ICollection<TProperty>>
            >
            collectionPropertyPredicate
    )
    :
        FilterParameterBase<TEntity>
{
    public override Expression
    <
        Func<TEntity, bool>
    > GetPredicate() =>
        entity =>
            !collectionPropertyPredicate
                .Invoke(
                    entity
                )
                .Any();
}