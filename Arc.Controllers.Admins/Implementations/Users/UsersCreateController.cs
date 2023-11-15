using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Users;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Users;

public sealed class UsersCreateController(
    IUsersCreateFacade
        facade
) :
    AdminAuthorizedArcController(
        facade
    )
{
    [HttpPost]
    [ProducesOkResponseType]
    public async Task<IActionResult> Call(
        [FromBody]
        CreateUserAdminRequest request
    ) =>
        await
            Invoke(
                request
            );
}