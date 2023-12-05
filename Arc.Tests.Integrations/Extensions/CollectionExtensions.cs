using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using LinqKit;

namespace Arc.Tests.Integrations.Extensions;

[SuppressMessage(
    "ReSharper",
    "PossibleMultipleEnumeration"
)]
public static class CollectionExtensions
{
    public static void ShouldBeAll<T>(
        this IEnumerable<T> collection,
        T expected
    )
    {
        collection
            .Should()
            .NotBeEmpty();

        collection
            .ForEach(
                item =>
                    item
                        .Should()
                        .Be(
                            expected
                        )
            );
    }
}