using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;
using Arc.Models.Views.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.ComplexProperties;

[ControllerGroup(
    "ComplexProperties"
)]
public sealed class ComplexPropertiesTableController(
        IComplexPropertiesTableFacade
            facade
    )
    :
        BaseTableAuthorizedController(facade
    )
{
    [HttpGet]
    [ProducesOkResponseType(
        typeof(IReadOnlyList<ComplexPropertyReadResponse>)
    )]
    public override async Task<IActionResult> Read(
        [FromQuery]
        TableReadRequest request
    ) =>
        await
            Invoke(
                request
            );
}