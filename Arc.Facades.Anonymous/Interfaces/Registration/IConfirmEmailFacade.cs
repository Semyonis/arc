using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Interfaces.Registration;

public interface IConfirmEmailFacade :
    IFunctionFacade<ConfirmEmailRequest> { }