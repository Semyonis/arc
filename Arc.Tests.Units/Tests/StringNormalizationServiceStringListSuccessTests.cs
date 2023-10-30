using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

using Xunit;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceStringListSuccessTests
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

        IReadOnlyList<string> value =
            new[]
            {
                BadString,
                BadString,
            };

        var result =
            (IReadOnlyList<string>)factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
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