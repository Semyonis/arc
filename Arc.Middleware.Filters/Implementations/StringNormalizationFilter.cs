using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Common.Extensions;

namespace Arc.Middleware.Filters.Implementations;

public sealed class StringNormalizationFilter :
    IAsyncActionFilter
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
                _objectNormalizeStringFacade
                    .NormalizeStringFields(
                        contextActionArgument
                    );

            context.ActionArguments[key] =
                normalizeStringFields;
        }

        await
            next();
    }

#region Constructor

    private readonly IObjectNormalizeStringFacade
        _objectNormalizeStringFacade;

    public StringNormalizationFilter(
        IObjectNormalizeStringFacade
            objectNormalizeStringFacade
    ) =>
        _objectNormalizeStringFacade =
            objectNormalizeStringFacade;

#endregion
}