using Arc.Controllers.Authorized.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Authorized.Interfaces;
using Arc.Models.Views.Common.Models;

namespace Arc.Controllers.Authorized.Implementations.Identity;

public sealed class ActorTypeController :
    AuthorizedArcController
{
    public ActorTypeController(
        IActorTypeFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpGet(
        "{email}"
    )]
    [ProducesOkResponseType(
        typeof(ActorTypeResponse)
    )]
    public async Task<IActionResult> Call(
        string email
    ) =>
        await
            Invoke(
                email
            );
}