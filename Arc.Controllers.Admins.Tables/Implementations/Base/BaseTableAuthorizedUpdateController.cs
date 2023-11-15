using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.Base;
using Arc.Models.Views.Admins.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.Base;

public abstract class BaseTableAuthorizedUpdateController<TUpdateRequest>(
        IExtendedTableUpdateFacade<TUpdateRequest>
            facade
    )
    :
        AdminAuthorizedArcController(facade
    )
{
    [HttpPut]
    [ProducesOkResponseType(
        typeof(TableActionResultResponse)
    )]
    public async Task<IActionResult> Call(
        TUpdateRequest request
    ) =>
        await
            Invoke(
                request
            );
}