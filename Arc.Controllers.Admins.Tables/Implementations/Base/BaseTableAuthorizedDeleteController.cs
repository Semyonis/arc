using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.Base;
using Arc.Models.Views.Admins.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.Base;

public abstract class BaseTableAuthorizedDeleteController(
    IExtendedTableDeleteFacade
        facade
) :
    AdminAuthorizedArcController(facade
    )
{
    [HttpDelete]
    [ProducesOkResponseType(
        typeof(TableActionResultResponse)
    )]
    public async Task<IActionResult> Call(
        IReadOnlyList<int> ids
    ) =>
        await
            Invoke(
                ids
            );
}