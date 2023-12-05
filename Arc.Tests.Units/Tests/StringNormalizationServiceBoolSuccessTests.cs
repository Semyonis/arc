using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceBoolSuccessTests
{
    [Fact]
    public void SuccessTest()
    {
        const bool Value =
            true;

        var factory =
            new Factory();

        var service =
            factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>();

        var result =
            service
                .Normalize(
                Value
            );

        var booleanContainer =
            result
                .Should()
                .BeOfType<bool>();

        booleanContainer
            .Subject
            .Should()
            .BeTrue();
    }
}