using Arc.Infrastructure.Services.Attributes;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

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
            factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        var objectWithStringsAndAttributeResult =
            result
                .Should()
                .BeOfType<ObjectWithStringsAndAttribute>();

        objectWithStringsAndAttributeResult
            .Subject
            .DontNormalize
            .Should()
            .Be(
                BadString
            );

        objectWithStringsAndAttributeResult
            .Subject
            .Normalize
            .Should()
            .Be(
                NormalizedString
            );
    }

    private sealed record ObjectWithStringsAndAttribute(
        string? Normalize,
        [property: DontNormalizeString]
        string? DontNormalize
    );
}