using Arc.Criteria.FilterParameters.Implementations.Base;

namespace Arc.Criteria.FilterParameters.Implementations;

public sealed class PropertyFilterParameter
    <
        TEntity,
        TProperty
    >(
        Expression
            <
                Func<TEntity, TProperty>
            >
            propertyPredicate,
        Expression
            <
                Func<TProperty, TProperty, bool>
            >
            compareFunction,
        TProperty
            value
    )
    :
        FilterParameterBase
    <
        TEntity
    >
{
    public override Expression
    <
        Func<TEntity, bool>
    > GetPredicate() =>
        entity =>
            compareFunction
                .Invoke(
                    propertyPredicate
                        .Invoke(
                            entity
                        ),
                    value
                );
}