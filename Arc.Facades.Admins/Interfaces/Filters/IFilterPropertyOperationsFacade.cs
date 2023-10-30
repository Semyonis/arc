using Arc.Facades.Base.Interfaces.Executors;
using Arc.Facades.Base.Interfaces.Validators;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Facades.Admins.Interfaces.Filters;

public interface IFilterPropertyOperationsFacade :
    IValidationFacade<AdminIdentity>,
    IFunctionFacade<string> { }