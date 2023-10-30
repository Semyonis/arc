namespace Arc.Criteria.FilterParameters.Implementations;

public abstract class FilterParameterBase<TEntity>
{
    public abstract Expression
    <
        Func<TEntity, bool>
    > GetPredicate();
}