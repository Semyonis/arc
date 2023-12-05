using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

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
            factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        var stringArrayResult =
            result
                .Should()
                .BeOfType<string[]>();

        stringArrayResult
            .Subject
            .Should()
            .AllBe(
                NormalizedString
            );
    }
}