using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.CompareFunctions.Implementations;

public sealed class BooleanCompareFunctions(
    IUnsupportedOperationExceptionDescriptor
        unsupportedOperationExceptionDescriptor
) : IBooleanCompareFunctions
{
    public Expression<Func<bool, bool, bool>> GetFunction(
        string operation
    ) =>
        operation switch
        {
            Equal =>
                GetBoolIsEqualFunction(),
            NotEqual =>
                GetBoolIsNotEqualFunction(),
            _ =>
                throw
                    unsupportedOperationExceptionDescriptor.CreateException(),
        };

    private static Expression<Func<bool, bool, bool>>
        GetBoolIsEqualFunction() =>
        (
                first,
                second
            ) =>
            first == second;

    private static Expression<Func<bool, bool, bool>>
        GetBoolIsNotEqualFunction() =>
        (
                first,
                second
            ) =>
            first != second;
}