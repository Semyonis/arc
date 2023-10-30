using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.Views.Users.Models;

namespace Arc.Facades.Users.Interfaces;

public interface IProfileUpdateFacade :
    IExtendedFunctionFacade
    <
        UserRequest,
        UserIdentity
    > { }