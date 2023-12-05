using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Units.Factories;

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
           factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    array
                );

        var stringArrayResult =
            result
                .Should()
                .BeOfType<string[]>();

        stringArrayResult
            .Subject
            .ShouldBeAll(
                NormalizedString
            );
    }
}