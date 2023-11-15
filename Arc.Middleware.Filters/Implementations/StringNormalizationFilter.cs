using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Common.Extensions;

namespace Arc.Middleware.Filters.Implementations;

public sealed class StringNormalizationFilter(
    IObjectNormalizeStringFacade
        objectNormalizeStringFacade
) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next
    )
    {
        var isEmpty =
            context
                .ActionArguments
                .IsEmpty();

        if (isEmpty)
        {
            await
                next();

            return;
        }

        var keys =
            context
                .ActionArguments
                .Keys
                .ToList();

        foreach (var key in keys)
        {
            var contextActionArgument =
                context.ActionArguments[key];

            var normalizeStringFields =
                objectNormalizeStringFacade
                    .NormalizeStringFields(
                        contextActionArgument
                    );

            context.ActionArguments[key] =
                normalizeStringFields;
        }

        await
            next();
    }
}