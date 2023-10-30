using Arc.Facades.Base.Interfaces.Methods;
using Arc.Facades.Base.Interfaces.Validators;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Facades.Admins.Interfaces.Filters;

public interface IComplexPropertyTableFiltersFacade :
    IValidationFacade<AdminIdentity>,
    IMethodFacade { }