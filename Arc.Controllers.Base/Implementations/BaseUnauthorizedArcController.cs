using Arc.Facades.Base.Interfaces.Executors;
using Arc.Facades.Base.Interfaces.Methods;

namespace Arc.Controllers.Base.Implementations;

public abstract class BaseUnauthorizedArcController(
    object
        facade
) :
    BaseArcController(facade
    )
{
    protected async Task<IActionResult> Invoke
    <
        TRequestArgs
    >(
        TRequestArgs args
    )
    {
        var executionFacade =
            facade as IFunctionFacade<TRequestArgs>;

        var responseDto =
            await
                executionFacade!
                    .Execute(
                        args
                    );

        return
            CreateResponse(
                responseDto
            );
    }

    protected async Task<IActionResult> Invoke()
    {
        var executionFacade =
            facade as IMethodFacade;

        var responseDto =
            await
                executionFacade!.Execute();

        return
            CreateResponse(
                responseDto
            );
    }
}