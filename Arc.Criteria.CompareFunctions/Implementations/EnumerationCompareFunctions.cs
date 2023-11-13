using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.CompareFunctions.Implementations;

public sealed class EnumerationCompareFunctions :
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
                    _unsupportedOperationExceptionDescriptor.CreateException(),
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

#region Constructor

    private readonly IUnsupportedOperationExceptionDescriptor
        _unsupportedOperationExceptionDescriptor;

    public EnumerationCompareFunctions(
        IUnsupportedOperationExceptionDescriptor
            unsupportedOperationExceptionDescriptor
    ) =>
        _unsupportedOperationExceptionDescriptor =
            unsupportedOperationExceptionDescriptor;

#endregion
}