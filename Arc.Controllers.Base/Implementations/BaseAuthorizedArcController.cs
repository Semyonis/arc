using System;

using Arc.Facades.Base.Interfaces.Executors;
using Arc.Facades.Base.Interfaces.Methods;
using Arc.Facades.Base.Interfaces.Validators;
using Arc.Infrastructure.Common.Models;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Controllers.Base.Implementations;

public abstract class BaseAuthorizedArcController<TIdentity>(
    object
        facade
) :
    BaseArcController(
        facade
    )
    where TIdentity : BaseIdentity
{
    protected async Task<IActionResult> Invoke
    <
        TRequestArgs
    >(
        TRequestArgs args
    )
    {
        var identity =
            GetActorIdentity();

        await
            ValidateFacadeExecution(
                identity
            );

        await
            ValidateExtendedFacadeExecution(
                args,
                identity
            );

        var responseDto =
            facade switch
            {
                IFunctionFacade
                    <
                        TRequestArgs
                    > executionFacade =>
                    await
                        executionFacade
                            .Execute(
                                args
                            ),
                IExtendedFunctionFacade
                    <
                        TRequestArgs,
                        TIdentity
                    >
                    extendedExecutionFacade =>
                    await
                        extendedExecutionFacade
                            .Execute(
                                args,
                                identity
                            ),
                _ => throw
                    new ArgumentOutOfRangeException(),
            };

        return
            CreateResponse(
                responseDto
            );
    }

    protected async Task<IActionResult> Invoke()
    {
        var identity =
            GetActorIdentity();

        await
            ValidateFacadeExecution(
                identity
            );

        var responseDto =
            facade switch
            {
                IMethodFacade executionFacade =>
                    await
                        executionFacade
                            .Execute(),
                IExtendedMethodFacade
                    <
                        TIdentity
                    > extendedExecutionFacade =>
                    await
                        extendedExecutionFacade
                            .Execute(
                                identity
                            ),
                _ => throw
                    new ArgumentOutOfRangeException(),
            };

        return
            CreateResponse(
                responseDto
            );
    }

    private async Task ValidateFacadeExecution(
        TIdentity identity
    )
    {
        if (facade is IValidationFacade<TIdentity> validationFacade)
        {
            await
                validationFacade
                    .Validate(
                        identity
                    );
        }
    }

    private async Task ValidateExtendedFacadeExecution<TRequestArgs>(
        TRequestArgs args,
        TIdentity identity
    )
    {
        if (facade is IExtendedValidationFacade
            <
                TRequestArgs,
                TIdentity
            >
            extendedValidationFacade)
        {
            await
                extendedValidationFacade
                    .Validate(
                        args,
                        identity
                    );
        }
    }
    
    private TIdentity GetActorIdentity()
    {
        var identity =
            ReadActorIdentity();

        return
            identity.Value!;
    }

    protected abstract ResultContainer<TIdentity> ReadActorIdentity();
}