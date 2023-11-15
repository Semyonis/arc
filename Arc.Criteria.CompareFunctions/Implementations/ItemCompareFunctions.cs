using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.CompareFunctions.Implementations;

public sealed class ItemCompareFunctions(
    IUnsupportedOperationExceptionDescriptor
        unsupportedOperationExceptionDescriptor
) : IItemCompareFunctions
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
                    unsupportedOperationExceptionDescriptor.CreateException(),
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
}