namespace Arc.Criteria.FilterParameters.Implementations.Base;

public abstract class FilterParameterBase<TEntity>
{
    public abstract Expression
    <
        Func<TEntity, bool>
    > GetPredicate();
}