using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Admins;

public sealed class AdminsPasswordUpdateController :
    AdminAuthorizedArcController
{
    public AdminsPasswordUpdateController(
        IAdminsPasswordUpdateFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpPost]
    [ProducesOkResponseType]
    public async Task<IActionResult> Call(
        AdminPasswordRequest request
    ) =>
        await
            Invoke(
                request
            );
}