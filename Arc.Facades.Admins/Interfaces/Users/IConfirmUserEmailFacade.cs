using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Facades.Admins.Interfaces.Users;

public interface IConfirmUserEmailFacade :
    IExtendedFunctionFacade
    <
        int,
        AdminIdentity
    > { }