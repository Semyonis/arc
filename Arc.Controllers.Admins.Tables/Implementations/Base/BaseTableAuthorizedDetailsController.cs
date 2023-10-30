using Arc.Facades.Admins.Tables.Interfaces.Base;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.Base;

public abstract class BaseTableAuthorizedDetailsController :
    AdminAuthorizedArcController
{
    protected BaseTableAuthorizedDetailsController(
        IExtendedTableDetailsFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpGet(
        "{entityId:int}"
    )]
    public abstract Task<IActionResult> GetById(
        int entityId
    );
}