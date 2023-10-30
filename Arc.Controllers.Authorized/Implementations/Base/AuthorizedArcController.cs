using Arc.Controllers.Base.Implementations;

using Microsoft.AspNetCore.Authorization;

namespace Arc.Controllers.Authorized.Implementations.Base;

[Authorize]
public abstract class AuthorizedArcController :
    BaseUnauthorizedArcController
{
    protected AuthorizedArcController(
        object
            facade
    ) : base(
        facade
    ) { }
}