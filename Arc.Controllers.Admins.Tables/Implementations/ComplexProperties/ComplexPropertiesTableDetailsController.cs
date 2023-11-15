using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.ComplexProperties;

[ControllerGroup(
    "ComplexProperties"
)]
public sealed class ComplexPropertiesTableDetailsController(
        IComplexPropertiesTableDetailsFacade
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
        typeof(ComplexPropertyReadResponse)
    )]
    public override async Task<IActionResult> GetById(
        int entityId
    ) =>
        await
            Invoke(
                entityId
            );
}