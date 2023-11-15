using Arc.Facades.Base.Interfaces.Executors;
using Arc.Facades.Base.Interfaces.Validators;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Interfaces.Users;

public interface IUsersCreateFacade :
    IValidationFacade<AdminIdentity>,
    IFunctionFacade<CreateUserAdminRequest>;