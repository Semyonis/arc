using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.CompareFunctions.Implementations;

public sealed class EnumerationCompareFunctions(
        IUnsupportedOperationExceptionDescriptor
            unsupportedOperationExceptionDescriptor
    )
    :
        IEnumerationCompareFunctions
{
    public Expression<Func<string, string, bool>> GetFunction(
        string operation
    ) =>
        operation switch
        {
            Equal =>
                GetEnumerationIsEqualFunction(),
            NotEqual =>
                GetEnumerationIsNotEqualFunction(),
            _ =>
                throw
                    unsupportedOperationExceptionDescriptor.CreateException(),
        };

    private static Expression<Func<string, string, bool>>
        GetEnumerationIsEqualFunction() =>
        (
                first,
                second
            ) =>
            first == second;

    private static Expression<Func<string, string, bool>>
        GetEnumerationIsNotEqualFunction() =>
        (
                first,
                second
            ) =>
            first != second;
}