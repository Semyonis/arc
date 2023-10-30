namespace Arc.Criteria.CompareFunctions.Interfaces;

public interface ICompareFunctionsBase<TType>
{
    Expression<Func<TType, TType, bool>> GetFunction(
        string operation
    );
}