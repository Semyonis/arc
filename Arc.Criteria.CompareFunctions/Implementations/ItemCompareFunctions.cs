using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.CompareFunctions.Implementations;

public sealed class ItemCompareFunctions :
    IItemCompareFunctions
{
    public Expression<Func<int, int, bool>> GetFunction(
        string operation
    ) =>
        operation switch
        {
            Equal =>
                GetItemIsContainsFunction(),
            NotEqual =>
                GetItemIsNotContainsFunction(),
            _ =>
                throw
                    _unsupportedOperationExceptionDescriptor.CreateException(),
        };

    private static Expression<Func<int, int, bool>>
        GetItemIsContainsFunction() =>
        (
                first,
                second
            ) =>
            first == second;

    private static Expression<Func<int, int, bool>>
        GetItemIsNotContainsFunction() =>
        (
                first,
                second
            ) =>
            first != second;

#region Constructor

    private readonly IUnsupportedOperationExceptionDescriptor
        _unsupportedOperationExceptionDescriptor;

    public ItemCompareFunctions(
        IUnsupportedOperationExceptionDescriptor
            unsupportedOperationExceptionDescriptor
    ) =>
        _unsupportedOperationExceptionDescriptor =
            unsupportedOperationExceptionDescriptor;

#endregion
}