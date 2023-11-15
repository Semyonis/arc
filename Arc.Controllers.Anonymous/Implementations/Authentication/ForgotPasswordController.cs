using Arc.Controllers.Anonymous.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Controllers.Anonymous.Implementations.Authentication;

[ControllerGroup(
    "Authentication"
)]
public sealed class ForgotPasswordController(
    IForgotPasswordFacade
        facade
) :
    AnonymousArcController(facade
    )
{
    [HttpPost]
    [ProducesOkResponseType(
        typeof(string)
    )]
    public async Task<IActionResult> Call(
        [FromBody]
        ForgotPasswordRequest model
    ) =>
        await
            Invoke(
                model
            );
}