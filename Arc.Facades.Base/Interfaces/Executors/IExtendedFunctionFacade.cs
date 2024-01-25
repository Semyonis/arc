using Arc.Models.BusinessLogic.Models;

namespace Arc.Facades.Base.Interfaces.Executors;

public interface IExtendedFunctionFacade
<
    in TRequest
>
{
    Task<Response> Execute(
        TRequest request,
        ArcIdentity identity
    );
}