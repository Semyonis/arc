using Arc.Infrastructure.Services.Interfaces;
using Arc.Tests.Units.Factories;

namespace Arc.Tests.Units.Tests;

public sealed class StringNormalizationServiceObjectWithObjectAndStringArrayAndObjectListSuccessTests
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

        IReadOnlyList<ObjectWithObjectAndStringArrayAndObjectList> value =
            new List<ObjectWithObjectAndStringArrayAndObjectList>
            {
                new(
                    new(
                        new List<string>
                        {
                            BadString,
                        },
                        default
                    ),
                    new[]
                    {
                        BadString,
                        BadString,
                    },
                    new List<ObjectWithStringListsAndObject>
                    {
                        new(
                            new[]
                            {
                                BadString,
                            },
                            new(
                                BadString
                            )
                        ),
                    }
                ),
            };

        var result =
            factory
                .DependencyFactory
                .GetImplementation<IStringNormalizationService>()
                .Normalize(
                    value
                );

        var resultContainer =
            result
                .Should()
                .BeOfType<List<ObjectWithObjectAndStringArrayAndObjectList>>();

            resultContainer
                .Subject[0]
                .SecondStringArray
                .Should()
                .AllBe(
                    NormalizedString
                );

            resultContainer
                .Subject[0]
                .FirstObject
                .FirstStringList
                .Should()
                .AllBe(
                    NormalizedString
                );

        var thirdCondition =
            resultContainer
                .Subject[0]
                .ThirdObjectList
                .All(
                    objectWithStringListsAndObject =>
                        objectWithStringListsAndObject
                            .FirstStringList
                            .All(
                                item =>
                                    item == NormalizedString
                            )
                        && objectWithStringListsAndObject
                            .SecondObject?
                            .FirstString
                        == NormalizedString
                );

        thirdCondition
            .Should()
            .BeTrue();
    }

    private sealed record ObjectWithStrings(
        string? FirstString
    );

    private sealed record ObjectWithStringListsAndObject(
        IReadOnlyList<string?> FirstStringList,
        ObjectWithStrings? SecondObject
    );

    private sealed record ObjectWithObjectAndStringArrayAndObjectList(
        ObjectWithStringListsAndObject FirstObject,
        string?[] SecondStringArray,
        IReadOnlyList<ObjectWithStringListsAndObject> ThirdObjectList
    );
}