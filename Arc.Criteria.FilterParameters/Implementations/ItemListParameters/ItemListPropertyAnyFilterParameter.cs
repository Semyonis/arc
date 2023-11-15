using Arc.Criteria.FilterParameters.Implementations.Base;

namespace Arc.Criteria.FilterParameters.Implementations.ItemListParameters;

public sealed class ItemListPropertyAnyFilterParameter<TEntity, TProperty>(
        Expression
            <
                Func<TEntity, ICollection<TProperty>>
            >
            collectionPropertyPredicate,
        Expression
            <
                Func<TProperty, int>
            >
            propertyValuePredicate,
        int
            value
    )
    :
        FilterParameterBase<TEntity>
{
    public override Expression
    <
        Func<TEntity, bool>
    > GetPredicate() =>
        entity =>
            collectionPropertyPredicate
                .Invoke(
                    entity
                )
                .Any(
                    property =>
                        propertyValuePredicate
                            .Invoke(
                                property
                            )
                        == value
                );
}