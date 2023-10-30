using System.Diagnostics.CodeAnalysis;

namespace Arc.Infrastructure.Common.Extensions;

[SuppressMessage(
    "ReSharper",
    "PossibleMultipleEnumeration"
)]
public static class EnumerableExtensions
{
    public static bool IsEmpty<TEntity>(
        [NotNullWhen(
            returnValue: false
        )]
        this IEnumerable<TEntity>? collection
    ) =>
        collection == null
        || !collection.Any();

    public static bool IsNotEmpty<TEntity>(
        [NotNullWhen(
            returnValue: true
        )]
        this IEnumerable<TEntity>? enumerable
    ) =>
        enumerable != null
        && enumerable.Any();
}