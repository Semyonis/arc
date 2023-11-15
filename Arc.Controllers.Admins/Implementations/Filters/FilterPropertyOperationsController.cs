using System.Collections.Generic;

using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Filters;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Controllers.Admins.Implementations.Filters;

public sealed class FilterPropertyOperationsController(
        IFilterPropertyOperationsFacade
            facade
    )
    :
        AdminAuthorizedArcController(facade
    )
{
    [HttpGet]
    [ProducesOkResponseType(
        typeof(IReadOnlyList<FilterPropertyOperatorModel>)
    )]
    public async Task<IActionResult> Call(
        string request
    ) =>
        await
            Invoke(
                request
            );
}