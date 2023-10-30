using Arc.Controllers.Base.Attributes;
using Arc.Controllers.Users.Implementations.Base;
using Arc.Facades.Users.Interfaces;
using Arc.Models.Views.Users.Models;

namespace Arc.Controllers.Users.Implementations.Users;

[ControllerGroup(
    "User"
)]
public sealed class ProfileUpdateController :
    UserAuthorizedArcController
{
    public ProfileUpdateController(
        IProfileUpdateFacade
            executionFacade
    ) : base(
        executionFacade
    ) { }

    [HttpPut]
    [ProducesOkResponseType]
    public async Task<IActionResult> Call(
        [FromBody]
        UserRequest model
    ) =>
        await
            Invoke(
                model
            );
}