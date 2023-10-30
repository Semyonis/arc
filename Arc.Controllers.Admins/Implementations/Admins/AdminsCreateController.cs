using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Models.Views.Admins.Models;

namespace Arc.Controllers.Admins.Implementations.Admins;

public sealed class AdminsCreateController :
    AdminAuthorizedArcController
{
    public AdminsCreateController(
        IAdminsCreateFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpPost]
    [ProducesOkResponseType(
        typeof(int)
    )]
    public async Task<IActionResult> Call(
        AdminCreateRequest request
    ) =>
        await
            Invoke(
                request
            );
}