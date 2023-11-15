using Arc.Controllers.Anonymous.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Anonymous.Interfaces.Service;
using Arc.Models.Views.Common.Models;

namespace Arc.Controllers.Anonymous.Implementations.Service;

public sealed class CurrentModeServiceController(
    ICurrentModeServiceFacade
        facade
) :
    AnonymousArcController(
        facade
    )
{
    [HttpGet]
    [ProducesOkResponseType(
        typeof(CurrentModeResponse)
    )]
    public async Task<IActionResult> Call() =>
        await
            Invoke();
}