using Arc.Infrastructure.Common.Constants;

using Microsoft.AspNetCore.Authorization;

namespace Arc.Controllers.Base.Attributes;

public sealed class UserAuthorizeAttribute :
    AuthorizeAttribute
{
    public UserAuthorizeAttribute() =>
        Roles =
            ActorTypeConstants.User;
}