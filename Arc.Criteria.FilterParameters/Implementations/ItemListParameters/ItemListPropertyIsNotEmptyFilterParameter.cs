namespace Arc.Criteria.FilterParameters.Implementations.ItemListParameters;

public sealed class ItemListPropertyIsNotEmptyFilterParameter
<
    TEntity,
    TProperty
> :
    FilterParameterBase
    <
        TEntity
    >
{
    private readonly Expression
        <
            Func
            <
                TEntity,
                ICollection<TProperty>
            >
        >
        _collectionPropertyPredicate;

    public ItemListPropertyIsNotEmptyFilterParameter(
        Expression
            <
                Func
                <
                    TEntity,
                    ICollection<TProperty>
                >
            >
            collectionPropertyPredicate
    ) =>
        _collectionPropertyPredicate =
            collectionPropertyPredicate;

    public override Expression
    <
        Func
        <
            TEntity,
            bool
        >
    > GetPredicate() =>
        entity =>
            _collectionPropertyPredicate
                .Invoke(
                    entity
                )
                .Any();
}