using Arc.Controllers.Admins.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Interfaces.Backdoors;

namespace Arc.Controllers.Admins.Implementations.Backdoors;

public sealed class DictionaryUpdateController(
    IDictionaryUpdateFacade
        facade
) :
    AdminAuthorizedArcController(
        facade
    )
{
    [HttpPost]
    [ProducesOkResponseType]
    public async Task<IActionResult> Call() =>
        await
            Invoke();
}