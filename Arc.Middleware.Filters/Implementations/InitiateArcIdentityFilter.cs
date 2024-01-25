using System.Security.Claims;

using Arc.Infrastructure.Common;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Models;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Middleware.Filters.Implementations;

public sealed class InitiateArcIdentityFilter :
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

        var container =
            GetArcIdentity(
                user
            );

        if (container.IsSuccess)
        {
            var arcIdentity =
                container.Value;

            httpContext
                .Items
                .Add(
                    ArcIdentityConstants.ArcIdentity,
                    arcIdentity
                );
        }

        await
            next();
    }

    private static ResultContainer<ArcIdentity> GetArcIdentity(
        ClaimsPrincipal? principal
    )
    {
        var actorTypeString =
            GetValue(
                principal,
                ClaimTypeConstants.ActorType
            );
        
        var actorIdString =
            GetValue(
                principal,
                ClaimTypeConstants.ActorId
            );

        var isSuccess =
            Enum
                .TryParse(
                    actorTypeString,
                    out ActorTypes actorType
                );

        var actorId =
            actorIdString.ParseToNullableInteger();

        var isFailed =
            !isSuccess
            || actorId == default;

        if (isFailed)
        {
            return
                ResultContainer<ArcIdentity>.Failed();
        }

        var arcIdentity =
            new ArcIdentity(
                actorId!.Value,
                actorType
            );

        return
            ResultContainer<ArcIdentity>
                .Successful(
                    arcIdentity
                );
    }

    private static string GetValue(
        ClaimsPrincipal? user,
        string claimName
    )
    {
        if (user == default)
        {
            return
                string.Empty;
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
}