using System.Collections.Generic;

using LinqKit;

namespace Arc.Tests.Integrations.Extensions;

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