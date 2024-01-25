using Arc.Models.BusinessLogic.Models;

namespace Arc.Facades.Base.Interfaces.Validators;

public interface IExtendedValidationFacade
<
    in TRequest
>
{
    Task Validate(
        TRequest request,
        ArcIdentity identity
    );
}