using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

using Xunit;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceObjectWithStringsAndObjectSuccessTests
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
            new ObjectWithStringsAndObject(
                BadString,
                new(
                    BadString
                )
            );

        var result =
            (ObjectWithStringsAndObject)factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        Assert
            .Equal(
                NormalizedString,
                result.FirstString
            );

        Assert
            .Equal(
                NormalizedString,
                result.SecondObjectWithStrings.FirstString
            );
    }

    private sealed record ObjectWithStrings(
        string? FirstString
    );

    private sealed record ObjectWithStringsAndObject(
        string? FirstString,
        ObjectWithStrings SecondObjectWithStrings
    );
}