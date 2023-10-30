namespace Arc.Infrastructure.Common.Extensions;

public static class StringParseExtensions
{
    public static int? ParseToNullableInteger(
        this string filter
    )
    {
        var isValid =
            int
                .TryParse(
                    filter,
                    out var id
                );

        if (isValid)
        {
            return id;
        }

        return default;
    }
}