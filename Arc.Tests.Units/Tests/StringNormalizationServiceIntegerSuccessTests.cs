using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceIntegerSuccessTests
{
    [Fact]
    public void SuccessTest()
    {
        const int Integer =
            1;

        var factory =
            new Factory();

        var service =
            factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>();

        var result =
            service
                .Normalize(
                    Integer
                );

        var integerResult =
            result
                .Should()
                .BeOfType<int>();

        integerResult
            .Subject
            .Should()
            .Be(
                1
            );
    }
}