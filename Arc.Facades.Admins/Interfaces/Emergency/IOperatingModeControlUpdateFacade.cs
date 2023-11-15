using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Interfaces.Emergency;

public interface IOperatingModeControlUpdateFacade :
    IExtendedFunctionFacade
    <
        ServiceModeAdminEditRequest,
        AdminIdentity
    >;