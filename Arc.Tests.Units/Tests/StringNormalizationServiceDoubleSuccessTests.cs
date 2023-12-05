using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceDoubleSuccessTests
{
    [Fact]
    public void SuccessTest()
    {
        const double Value =
            0.1d;

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

        var doubleContainer =
            result
                .Should()
                .BeOfType<double>();

        var condition =
            doubleContainer.Subject - 0.1d < 0.001;

        condition
            .Should()
            .BeTrue();
    }
}