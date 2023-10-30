using Arc.Controllers.Base.Attributes;
using Arc.Controllers.Base.Implementations;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Models;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Controllers.Users.Implementations.Base;

[UserAuthorize]
[UserApiRoute]
public abstract class UserAuthorizedArcController :
    BaseAuthorizedArcController
    <
        UserIdentity
    >
{
    protected UserAuthorizedArcController(
        object
            facade
    ) : base(
        facade
    ) { }

    protected override ResultContainer<UserIdentity> ReadActorIdentity() =>
        GetItem<UserIdentity>(
            HttpContext,
            ActorTypeConstants.User
        );
}