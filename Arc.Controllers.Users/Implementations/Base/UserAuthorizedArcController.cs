using Arc.Controllers.Base.Attributes;
using Arc.Controllers.Base.Implementations;

namespace Arc.Controllers.Users.Implementations.Base;

[UserAuthorize]
[UserApiRoute]
public abstract class UserAuthorizedArcController(
    object
        facade
) :
    BaseAuthorizedArcController(
        facade
    );