using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Infrastructure.Common.Interfaces;

namespace Arc.Criteria.FilterParameters.Implementations;

public sealed class ItemPropertyFilterParameter
<
    TEntity,
    TProperty
>(
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
) : FilterParameterBase
<
    TEntity
>
    where TProperty : IWithIdentifier
{
    public override Expression
    <
        Func<TEntity, bool>
    > GetPredicate() =>
        entity =>
            compareFunction
                .Invoke(
                    collectionPropertyPredicate
                        .Invoke(
                            entity
                        )
                        .Id,
                    value
                );
}