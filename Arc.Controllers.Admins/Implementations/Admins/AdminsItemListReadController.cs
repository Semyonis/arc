using System.Collections.Generic;

using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Models.Views.Common.Models;

namespace Arc.Controllers.Admins.Implementations.Admins;

public sealed class AdminsItemListReadController(
    IAdminItemListReadFacade
        facade
) :
    AdminAuthorizedArcController(
        facade
    )
{
    [HttpGet]
    [ProducesOkResponseType(
        typeof(IReadOnlyList<ListItemResponse>)
    )]
    public async Task<IActionResult> Call() =>
        await
            Invoke();
}