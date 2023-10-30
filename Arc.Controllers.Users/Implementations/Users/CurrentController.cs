using Arc.Controllers.Base.Attributes;
using Arc.Controllers.Users.Implementations.Base;
using Arc.Facades.Users.Interfaces;
using Arc.Models.Views.Common.Models;

namespace Arc.Controllers.Users.Implementations.Users;

[ControllerGroup(
    "Users"
)]
public sealed class CurrentController :
    UserAuthorizedArcController
{
    public CurrentController(
        ICurrentFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpGet]
    [ProducesOkResponseType(
        typeof(UserResponse)
    )]
    public async Task<IActionResult> Call() =>
        await
            Invoke();
}