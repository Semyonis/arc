using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.SimpleProperties;

[ControllerGroup(
    "SimpleProperties"
)]
public sealed class SimplePropertiesTableDetailsController(
        ISimplePropertiesTableDetailsFacade
            facade
    )
    :
        BaseTableAuthorizedDetailsController(facade
    )
{
    [HttpGet(
        "{entityId:int}"
    )]
    [ProducesOkResponseType(
        typeof(SimplePropertyReadResponse)
    )]
    public override async Task<IActionResult> GetById(
        int entityId
    ) =>
        await
            Invoke(
                entityId
            );
}