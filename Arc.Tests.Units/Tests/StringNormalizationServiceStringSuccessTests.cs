using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

using Xunit;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceStringSuccessTests
{
    [Fact]
    public void SuccessTest()
    {
        var factory =
            new Factory();

        const string BadStringing =
            "  Is   not    normalized    string     ";

        const string NormalizedString =
            "Is not normalized string";

        var result =
            (string)factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    BadStringing
                );

        Assert
            .Equal(
                NormalizedString,
                result
            );
    }
}