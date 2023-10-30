using Arc.Infrastructure.Services.Attributes;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

using Xunit;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceObjectWithStringsAndAttributeSuccessTests
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

        var value =
            new ObjectWithStringsAndAttribute(
                BadString,
                BadString
            );

        var result =
            (ObjectWithStringsAndAttribute)factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        Assert
            .Equal(
                BadString,
                result.DontNormalize
            );

        Assert
            .Equal(
                NormalizedString,
                result.Normalize
            );
    }

    private sealed record ObjectWithStringsAndAttribute(
        string? Normalize,
        [property: DontNormalizeString]
        string? DontNormalize
    );
}