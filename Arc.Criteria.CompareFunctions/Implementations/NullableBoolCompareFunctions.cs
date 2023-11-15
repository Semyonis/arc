using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.CompareFunctions.Implementations;

public sealed class NullableBoolCompareFunctions(
    IUnsupportedOperationExceptionDescriptor
        unsupportedOperationExceptionDescriptor
) : INullableBoolCompareFunctions
{
    public Expression<Func<bool?, bool?, bool>> GetFunction(
        string operation
    ) =>
        operation switch
        {
            Equal =>
                GetBoolIsEqualFunction(),
            NotEqual =>
                GetBoolIsNotEqualFunction(),
            IsEmpty =>
                GetBoolIsNull(),
            IsNotEmpty =>
                GetBoolIsNotNull(),
            _ =>
                throw
                    unsupportedOperationExceptionDescriptor.CreateException(),
        };

    private static Expression<Func<bool?, bool?, bool>>
        GetBoolIsEqualFunction() =>
        (
                first,
                second
            ) =>
            first == second;

    private static Expression<Func<bool?, bool?, bool>>
        GetBoolIsNotEqualFunction() =>
        (
                first,
                second
            ) =>
            first != second;

    private static Expression<Func<bool?, bool?, bool>>
        GetBoolIsNull() =>
        (
                value,
                _
            ) =>
            value == default;

    private static Expression<Func<bool?, bool?, bool>>
        GetBoolIsNotNull() =>
        (
                value,
                _
            ) =>
            value != default;
}