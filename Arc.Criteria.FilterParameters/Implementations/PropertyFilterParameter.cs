namespace Arc.Criteria.FilterParameters.Implementations;

public sealed class PropertyFilterParameter
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
            Func<TProperty, TProperty, bool>
        >
        _compareFunction;

    private readonly Expression
        <
            Func<TEntity, TProperty>
        >
        _propertyPredicate;

    private readonly TProperty
        _value;

    public PropertyFilterParameter(
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
    {
        _propertyPredicate =
            propertyPredicate;

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
                    _propertyPredicate
                        .Invoke(
                            entity
                        ),
                    _value
                );
}