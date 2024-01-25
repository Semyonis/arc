using Arc.Models.BusinessLogic.Models;

namespace Arc.Facades.Base.Interfaces.Methods;

public interface IExtendedMethodFacade
{
    Task<Response> Execute(
        ArcIdentity identity
    );
}