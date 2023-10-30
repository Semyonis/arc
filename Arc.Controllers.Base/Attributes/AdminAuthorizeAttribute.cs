using Arc.Infrastructure.Common.Constants;

using Microsoft.AspNetCore.Authorization;

namespace Arc.Controllers.Base.Attributes;

public sealed class AdminAuthorizeAttribute :
    AuthorizeAttribute
{
    public AdminAuthorizeAttribute() =>
        Roles =
            ActorTypeConstants.Admin;
}