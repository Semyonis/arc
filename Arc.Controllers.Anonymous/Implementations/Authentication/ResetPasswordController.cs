using Arc.Controllers.Anonymous.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Controllers.Anonymous.Implementations.Authentication;

[ControllerGroup(
    "Authentication"
)]
public sealed class ResetPasswordController(
    IResetPasswordFacade
        facade
) :
    AnonymousArcController(facade
    )
{
    [HttpPost]
    public async Task<IActionResult> Call(
        [FromBody]
        ResetPasswordRequest model
    ) =>
        await
            Invoke(
                model
            );
}