using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Units.Factories;

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
            factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        var integerListContainer =
            result
                .Should()
                .BeOfType<List<int>>();

        integerListContainer
            .Subject
            .ShouldBeAll(
                1
            );
    }
}