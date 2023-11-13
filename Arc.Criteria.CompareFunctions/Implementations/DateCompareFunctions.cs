using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.CompareFunctions.Implementations;

public sealed class DateCompareFunctions :
    IDateCompareFunctions
{
    public Expression<Func<DateTime, DateTime, bool>> GetFunction(
        string operation
    ) =>
        operation switch
        {
            Equal =>
                GetBoolIsEqualFunction(),
            NotEqual =>
                GetBoolIsNotEqualFunction(),
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

    private static Expression<Func<DateTime, DateTime, bool>>
        GetBoolIsEqualFunction() =>
        (
                first,
                second
            ) =>
            first.Date == second.Date;

    private static Expression<Func<DateTime, DateTime, bool>>
        GetBoolIsNotEqualFunction() =>
        (
                first,
                second
            ) =>
            first.Date != second.Date;

    private static Expression<Func<DateTime, DateTime, bool>>
        GetIntegerIsGreaterFunction() =>
        (
                first,
                second
            ) =>
            first > second;

    private static Expression<Func<DateTime, DateTime, bool>>
        GetIntegerIsGreaterOrEqualFunction() =>
        (
                first,
                second
            ) =>
            first >= second;

    private static Expression<Func<DateTime, DateTime, bool>>
        GetIntegerIsLowerFunction() =>
        (
                first,
                second
            ) =>
            first < second;

    private static Expression<Func<DateTime, DateTime, bool>>
        GetIntegerIsLowerOrEqualFunction() =>
        (
                first,
                second
            ) =>
            first <= second;

#region Constructor

    private readonly IUnsupportedOperationExceptionDescriptor
        _unsupportedOperationExceptionDescriptor;

    public DateCompareFunctions(
        IUnsupportedOperationExceptionDescriptor
            unsupportedOperationExceptionDescriptor
    ) =>
        _unsupportedOperationExceptionDescriptor =
            unsupportedOperationExceptionDescriptor;

#endregion
}