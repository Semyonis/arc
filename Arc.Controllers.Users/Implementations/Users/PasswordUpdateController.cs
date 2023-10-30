using Arc.Controllers.Base.Attributes;
using Arc.Controllers.Users.Implementations.Base;
using Arc.Facades.Users.Interfaces;
using Arc.Models.Views.Users.Models;

namespace Arc.Controllers.Users.Implementations.Users;

[ControllerGroup(
    "User"
)]
public sealed class PasswordUpdateController :
    UserAuthorizedArcController
{
    public PasswordUpdateController(
        IPasswordUpdateFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpPost]
    [ProducesOkResponseType(
        typeof(string)
    )]
    public async Task<IActionResult> Call(
        [FromBody]
        ChangePasswordRequest model
    ) =>
        await
            Invoke(
                model
            );
}