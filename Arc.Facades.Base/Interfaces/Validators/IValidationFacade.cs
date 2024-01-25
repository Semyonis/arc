using Arc.Models.BusinessLogic.Models;

namespace Arc.Facades.Base.Interfaces.Validators;

public interface IValidationFacade
{
    Task Validate(
        ArcIdentity identity
    );
}