using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.Base;
using Arc.Models.Views.Admins.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.Base;

public abstract class BaseTableAuthorizedCreateController<TCreateRequest> :
    AdminAuthorizedArcController

{
    protected BaseTableAuthorizedCreateController(
        IExtendedTableCreateFacade<TCreateRequest>
            facade
    ) : base(
        facade
    ) { }

    [HttpPost]
    [ProducesOkResponseType(
        typeof(TableActionResultResponse)
    )]
    public async Task<IActionResult> Call(
        TCreateRequest request
    ) =>
        await
            Invoke(
                request
            );
}