using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Infrastructure.Common.Interfaces;

namespace Arc.Criteria.FilterParameters.Implementations;

public sealed class ItemPropertyFilterParameter
<
    TEntity,
    TProperty
> :
    FilterParameterBase
    <
        TEntity
    >
    where TProperty : IWithIdentifier
{
    private readonly Expression
        <
            Func<TEntity, TProperty>
        >
        _collectionPropertyPredicate;

    private readonly Expression
        <
            Func<int, int, bool>
        >
        _compareFunction;

    private readonly int
        _value;

    public ItemPropertyFilterParameter(
        Expression
            <
                Func<TEntity, TProperty>
            >
            collectionPropertyPredicate,
        Expression
            <
                Func<int, int, bool>
            >
            compareFunction,
        int
            value
    )
    {
        _collectionPropertyPredicate =
            collectionPropertyPredicate;

        _compareFunction =
            compareFunction;

        _value =
            value;
    }

    public override Expression
    <
        Func<TEntity, bool>
    > GetPredicate() =>
        entity =>
            _compareFunction
                .Invoke(
                    _collectionPropertyPredicate
                        .Invoke(
                            entity
                        )
                        .Id,
                    _value
                );
}