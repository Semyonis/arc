using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Users;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Users;

public sealed class UsersUpdateController :
    AdminAuthorizedArcController
{
    public UsersUpdateController(
        IUsersUpdateFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpPut]
    [ProducesOkResponseType]
    public async Task<IActionResult> Call(
        UserAdminEditRequest request
    ) =>
        await
            Invoke(
                request
            );
}