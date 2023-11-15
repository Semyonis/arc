using System.Security.Claims;

using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Middleware.Filters.Implementations;

public sealed class ValidateUserAccessFilter(
        IOperatingModeFilterFacade
            operatingModeFilterFacade,
        IServiceUnavailableExceptionDescriptor
            serviceUnavailableExceptionDescriptor
    )
    :
        IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next
    )
    {
        var httpContext =
            context.HttpContext;

        var user =
            httpContext.User;

        var actorType =
            GetActorType(
                user
            );

        var isAdmin =
            actorType
            == ActorTypeConstants.Admin;

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

    private static string GetActorType(
        ClaimsPrincipal? principal
    ) =>
        GetValue(
            principal,
            ClaimTypeConstants.ActorType
        );

    private static string GetValue(
        ClaimsPrincipal? user,
        string claimName
    )
    {
        if (user == default)
        {
            return string.Empty;
        }

        var value =
            user
                .FindFirst(
                    claimName
                );

        return
            value?.Value
            ?? string.Empty;
    }
#region Constructor

#endregion
}