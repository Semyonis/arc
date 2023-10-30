using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Interfaces.Admins;

public interface IAdminsCreateFacade :
    IExtendedFunctionFacade
    <
        AdminCreateRequest,
        AdminIdentity
    > { }