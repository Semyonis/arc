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
                    _badDataExceptionDescriptor.CreateException(),
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

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    public ItemCompareFunctions(
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor
    ) =>
        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;

#endregion
}