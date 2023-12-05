using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceObjectWithStringsSuccessTests
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
            new ObjectWithStrings(
                BadString
            );

        var result =
           factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        var objectWithStringsResult =
            result
                .Should()
                .BeOfType<ObjectWithStrings>();

        objectWithStringsResult
            .Subject
            .FirstString
            .Should()
            .Be(
                NormalizedString
            );
    }

    private sealed record ObjectWithStrings(
        string? FirstString
    );
}