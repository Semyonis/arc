using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

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
            factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        var objectWithStringsAndObjectResult =
            result
                .Should()
                .BeOfType<ObjectWithStringsAndObject>();

        var subject =
            objectWithStringsAndObjectResult.Subject;

        subject
            .FirstString
            .Should()
            .Be(
                NormalizedString
            );

        subject
            .SecondObjectWithStrings
            .FirstString
            .Should()
            .Be(
                NormalizedString
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