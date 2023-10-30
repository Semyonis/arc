using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

using Xunit;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceIntegerListSuccessTests
{
    [Fact]
    public void SuccessTest()
    {
        var factory =
            new Factory();

        IReadOnlyList<int> value =
            new List<int>
            {
                1,
                1,
            };

        var result =
            (IReadOnlyList<int>)factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        var condition =
            result
                .All(
                    item =>
                        item == 1
                );

        Assert
            .True(
                condition
            );
    }
}