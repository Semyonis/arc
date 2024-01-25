using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Common;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Middleware.Filters.Implementations;

public sealed class ValidateUserAccessFilter(
    IOperatingModeFilterFacade
        operatingModeFilterFacade,
    IServiceUnavailableExceptionDescriptor
        serviceUnavailableExceptionDescriptor
) : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next
    )
    {
        var httpContext =
            context.HttpContext;

        var httpContextItems =
            httpContext.Items;

        var isSuccess =
            httpContextItems
                .TryGetValue(
                    ArcIdentityConstants.ArcIdentity,
                    out var identity
                );

        var isAdmin =
            !isSuccess
            && identity is ArcIdentity { Type: ActorTypes.Admin, }; 

        if (isAdmin)
        {
            await
                next();

            return;
        }

        var currentMode =
            await
                operatingModeFilterFacade.GetCurrentMode();

        var isOff =
            currentMode
            == ServiceModeType.Off;

        if (isOff)
        {
            throw
                serviceUnavailableExceptionDescriptor.CreateException();
        }

        await
            next();
    }
}