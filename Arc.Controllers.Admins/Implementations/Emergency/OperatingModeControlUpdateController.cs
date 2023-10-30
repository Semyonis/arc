using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Emergency;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Emergency;

public sealed class OperatingModeControlUpdateController :
    AdminAuthorizedArcController
{
    public OperatingModeControlUpdateController(
        IOperatingModeControlUpdateFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpPost]
    [ProducesOkResponseType(
        typeof(ServiceModeAdminReadResponse)
    )]
    public async Task<IActionResult> Call(
        [FromBody]
        ServiceModeAdminEditRequest request
    ) =>
        await
            Invoke(
                request
            );
}