using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.Views.Users.Models;

namespace Arc.Facades.Users.Interfaces;

public interface IPasswordUpdateFacade :
    IExtendedFunctionFacade
    <
        ChangePasswordRequest
    >;