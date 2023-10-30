namespace Arc.Infrastructure.Common.Extensions;

public static class CollectionWrapperExtensions
{
    public static IReadOnlyList<T> WrapByReadOnlyList<T>(
        this T item
    ) =>
        new List<T>
        {
            item,
        };

    public static List<T> WrapByList<T>(
        this T item
    ) =>
        new()
        {
            item,
        };

    public static IReadOnlyList<T> ReplaceByEmptyListIfNull<T>(
        this IEnumerable<T>? itemList
    ) =>
        itemList?.ToList()
        ?? new List<T>();
}