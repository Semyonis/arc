using Arc.Facades.Admins.Tables.Interfaces.Base;
using Arc.Models.Views.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.Base;

public abstract class BaseTableAuthorizedController(
    IExtendedTableFacade
        facade
) :
    AdminAuthorizedArcController(facade
    )
{
    [HttpGet]
    public abstract Task<IActionResult> Read(
        [FromQuery]
        TableReadRequest request
    );
}