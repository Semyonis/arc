using Arc.Controllers.Base.Attributes;
using Arc.Controllers.Base.Implementations;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Models;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Controllers.Admins.Implementations.Base;

[AdminAuthorize]
[AdminApiRoute]
public abstract class AdminAuthorizedArcController(
    object
        facade
) :
    BaseAuthorizedArcController
    <
        AdminIdentity
    >(facade
    )
{
    protected override ResultContainer<AdminIdentity> ReadActorIdentity() =>
        GetItem<AdminIdentity>(
            HttpContext,
            ActorTypeConstants.Admin
        );
}