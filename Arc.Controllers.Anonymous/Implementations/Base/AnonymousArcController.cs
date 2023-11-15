using Arc.Controllers.Base.Implementations;

using Microsoft.AspNetCore.Authorization;

namespace Arc.Controllers.Anonymous.Implementations.Base;

[AllowAnonymous]
public abstract class AnonymousArcController(
    object
        facade
) :
    BaseUnauthorizedArcController(facade
    );