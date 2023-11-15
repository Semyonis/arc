using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;
using Arc.Models.Views.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.SimpleProperties;

[ControllerGroup(
    "SimpleProperties"
)]
public sealed class SimplePropertiesTableController(
        ISimplePropertiesTableFacade
            facade
    )
    :
        BaseTableAuthorizedController(facade
    )
{
    [HttpGet]
    [ProducesOkResponseType(
        typeof(IReadOnlyList<SimplePropertyReadResponse>)
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