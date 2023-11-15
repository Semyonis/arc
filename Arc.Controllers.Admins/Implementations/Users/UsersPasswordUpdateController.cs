using Arc.Controllers.Admins.Implementations.Base;
using Arc.Facades.Admins.Interfaces.Users;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Users;

public sealed class UsersPasswordUpdateController(
    IUsersPasswordUpdateFacade
        facade
) :
    AdminAuthorizedArcController(facade
    )
{
    [HttpPatch]
    public async Task<IActionResult> Call(
        ChangePasswordAdminRequest request
    ) =>
        await
            Invoke(
                request
            );
}