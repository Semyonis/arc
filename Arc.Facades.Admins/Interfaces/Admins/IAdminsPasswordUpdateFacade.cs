using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Interfaces.Admins;

public interface IAdminsPasswordUpdateFacade :
    IExtendedFunctionFacade
    <
        AdminPasswordRequest
    >;