using Arc.Controllers.Anonymous.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Controllers.Anonymous.Implementations.Registration;

[ControllerGroup(
    "Registration"
)]
public sealed class RegistrationController(
    IRegistrationFacade
        facade
) :
    AnonymousArcController(
        facade
    )
{
    [HttpPost]
    [ProducesOkResponseType(
        typeof(string)
    )]
    public async Task<IActionResult> Call(
        [FromBody]
        CreateUserRequest model
    ) =>
        await
            Invoke(
                model
            );
}