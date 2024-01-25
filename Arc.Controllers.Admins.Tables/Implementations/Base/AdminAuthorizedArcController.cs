using Arc.Controllers.Base.Attributes;
using Arc.Controllers.Base.Implementations;

namespace Arc.Controllers.Admins.Tables.Implementations.Base;

[AdminAuthorize]
[AdminApiRoute]
public abstract class AdminAuthorizedArcController(
    object
        facade
) :
    BaseAuthorizedArcController(
        facade
    );