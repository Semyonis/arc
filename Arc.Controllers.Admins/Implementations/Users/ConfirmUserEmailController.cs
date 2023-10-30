using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Users;

namespace Arc.Controllers.Admins.Implementations.Users;

public sealed class ConfirmUserEmailController :
    AdminAuthorizedArcController
{
    public ConfirmUserEmailController(
        IConfirmUserEmailFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpPut(
        "{userId:int}"
    )]
    [ProducesOkResponseType]
    public async Task<IActionResult> Call(
        int userId
    ) =>
        await
            Invoke(
                userId
            );
}