using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

using Xunit;

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
            (int)service
                .Normalize(
                    Integer
                );

        Assert
            .Equal(
                1,
                result
            );
    }
}