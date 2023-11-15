using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Interfaces.Authentication;

public interface IForgotPasswordFacade :
    IFunctionFacade<ForgotPasswordRequest>;