using System.Collections.Generic;

using Arc.Controllers.Authorized.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Authorized.Interfaces.Dictionaries;
using Arc.Models.Views.Common.Models;

namespace Arc.Controllers.Authorized.Implementations.Dictionaries;

[ControllerGroup(
    "Dictionaries"
)]
public sealed class SimplePropertyItemListController(
        ISimplePropertyItemListFacade
            facade
    )
    :
        AuthorizedArcController(facade
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