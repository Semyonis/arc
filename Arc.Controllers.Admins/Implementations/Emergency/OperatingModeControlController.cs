using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Emergency;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Emergency;

public sealed class OperatingModeControlController :
    AdminAuthorizedArcController
{
    public OperatingModeControlController(
        IOperatingModeControlFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpGet]
    [ProducesOkResponseType(
        typeof(ServiceModeAdminReadResponse)
    )]
    public async Task<IActionResult> Call() =>
        await
            Invoke();
}