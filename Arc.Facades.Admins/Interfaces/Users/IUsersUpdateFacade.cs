using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Interfaces.Users;

public interface IUsersUpdateFacade :
    IExtendedFunctionFacade
    <
        UserAdminEditRequest,
        AdminIdentity
    >;