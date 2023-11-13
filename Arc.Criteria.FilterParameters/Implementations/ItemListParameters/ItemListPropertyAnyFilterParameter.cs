using Arc.Criteria.FilterParameters.Implementations.Base;

namespace Arc.Criteria.FilterParameters.Implementations.ItemListParameters;

public sealed class ItemListPropertyAnyFilterParameter<TEntity, TProperty> :
    FilterParameterBase<TEntity>
{
    private readonly Expression
        <
            Func<TEntity, ICollection<TProperty>>
        >
        _collectionPropertyPredicate;

    private readonly Expression
        <
            Func<TProperty, int>
        >
        _propertyValuePredicate;

    private readonly int
        _value;

    public ItemListPropertyAnyFilterParameter(
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
    {
        _collectionPropertyPredicate =
            collectionPropertyPredicate;

        _propertyValuePredicate =
            propertyValuePredicate;

        _value =
            value;
    }

    public override Expression
    <
        Func<TEntity, bool>
    > GetPredicate() =>
        entity =>
            _collectionPropertyPredicate
                .Invoke(
                    entity
                )
                .Any(
                    property =>
                        _propertyValuePredicate
                            .Invoke(
                                property
                            )
                        == _value
                );
}