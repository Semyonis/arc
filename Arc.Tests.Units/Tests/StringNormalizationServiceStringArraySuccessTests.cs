using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

using Xunit;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceStringArraySuccessTests
{
    [Fact]
    public void SuccessTest()
    {
        var factory =
            new Factory();

        const string BadString =
            "  Is   not    normalized    string     ";

        const string NormalizedString =
            "Is not normalized string";

        var array =
            new[]
            {
                BadString,
                BadString,
            };

        var result =
            (string[])factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    array
                );

        var condition =
            result
                .All(
                    item =>
                        item == NormalizedString
                );

        Assert
            .True(
                condition
            );
    }
}