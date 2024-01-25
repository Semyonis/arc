using Arc.Facades.Base.Interfaces.Executors;
using Arc.Facades.Base.Interfaces.Validators;

namespace Arc.Facades.Admins.Interfaces.Filters;

public interface IFilterPropertyOperationsFacade :
    IValidationFacade,
    IFunctionFacade<string>;