using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Admins;

public sealed class AdminsUpdateController :
    AdminAuthorizedArcController
{
    public AdminsUpdateController(
        IAdminsUpdateFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpPut]
    [ProducesOkResponseType]
    public async Task<IActionResult> Call(
        AdminUpdateRequest request
    ) =>
        await
            Invoke(
                request
            );
}