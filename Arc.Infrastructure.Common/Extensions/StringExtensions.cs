using System.Diagnostics.CodeAnalysis;

namespace Arc.Infrastructure.Common.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(
        [NotNullWhen(
            returnValue: false
        )]
        this string? value
    ) =>
        string
            .IsNullOrWhiteSpace(
                value
            );

    public static bool IsNotEmpty(
        [NotNullWhen(
            returnValue: true
        )]
        this string? value
    ) =>
        !string
            .IsNullOrWhiteSpace(
                value
            );

    public static bool IsEqualTo(
        this string source,
        string pattern,
        StringComparison compareType =
            StringComparison.InvariantCultureIgnoreCase
    ) =>
        string
            .Equals(
                source,
                pattern,
                compareType
            );
}