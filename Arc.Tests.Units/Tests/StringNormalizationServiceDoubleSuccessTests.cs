using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

using Xunit;

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
            (double)service
                .Normalize(
                    Value
                );

        var condition =
            result - 0.1d < 0.001;

        Assert
            .True(
                condition
            );
    }
}