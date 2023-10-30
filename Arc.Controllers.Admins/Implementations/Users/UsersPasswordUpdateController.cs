using Arc.Controllers.Admins.Implementations.Base;
using Arc.Facades.Admins.Interfaces.Users;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Users;

public sealed class UsersPasswordUpdateController :
    AdminAuthorizedArcController
{
    public UsersPasswordUpdateController(
        IUsersPasswordUpdateFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpPatch]
    public async Task<IActionResult> Call(
        ChangePasswordAdminRequest request
    ) =>
        await
            Invoke(
                request
            );
}