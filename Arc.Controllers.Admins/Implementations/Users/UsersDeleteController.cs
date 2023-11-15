using Arc.Controllers.Admins.Implementations.Base;
using Arc.Facades.Admins.Interfaces.Users;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Users;

public sealed class UsersDeleteController(
    IUsersDeleteFacade
        facade
) :
    AdminAuthorizedArcController(
        facade
    )
{
    [HttpDelete]
    public async Task<IActionResult> Call(
        DeleteEntityAdminRequest request
    ) =>
        await
            Invoke(
                request
            );
}