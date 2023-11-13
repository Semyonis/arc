using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.CompareFunctions.Implementations;

public sealed class IntegerCompareFunctions :
    IIntegerCompareFunctions
{
    public Expression<Func<int, int, bool>> GetFunction(
        string operation
    ) =>
        operation switch
        {
            Equal =>
                GetIntegerIsEqualFunction(),
            NotEqual =>
                GetIntegerIsNotEqualFunction(),
            Greater =>
                GetIntegerIsGreaterFunction(),
            Lower =>
                GetIntegerIsLowerFunction(),
            GreaterOrEqual =>
                GetIntegerIsGreaterOrEqualFunction(),
            LowerOrEqual =>
                GetIntegerIsLowerOrEqualFunction(),
            _ =>
                throw
                    _unsupportedOperationExceptionDescriptor.CreateException(),
        };

    private static Expression<Func<int, int, bool>>
        GetIntegerIsEqualFunction() =>
        (
                first,
                second
            ) =>
            first == second;

    private static Expression<Func<int, int, bool>>
        GetIntegerIsNotEqualFunction() =>
        (
                first,
                second
            ) =>
            first != second;

    private static Expression<Func<int, int, bool>>
        GetIntegerIsGreaterFunction() =>
        (
                first,
                second
            ) =>
            first > second;

    private static Expression<Func<int, int, bool>>
        GetIntegerIsGreaterOrEqualFunction() =>
        (
                first,
                second
            ) =>
            first >= second;

    private static Expression<Func<int, int, bool>>
        GetIntegerIsLowerFunction() =>
        (
                first,
                second
            ) =>
            first < second;

    private static Expression<Func<int, int, bool>>
        GetIntegerIsLowerOrEqualFunction() =>
        (
                first,
                second
            ) =>
            first <= second;

#region Constructor

    private readonly IUnsupportedOperationExceptionDescriptor
        _unsupportedOperationExceptionDescriptor;

    public IntegerCompareFunctions(
        IUnsupportedOperationExceptionDescriptor
            unsupportedOperationExceptionDescriptor
    ) =>
        _unsupportedOperationExceptionDescriptor =
            unsupportedOperationExceptionDescriptor;

#endregion
}