using System;

using Arc.Facades.Base.Interfaces.Executors;
using Arc.Facades.Base.Interfaces.Methods;
using Arc.Facades.Base.Interfaces.Validators;
using Arc.Infrastructure.Common;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Controllers.Base.Implementations;

public abstract class BaseAuthorizedArcController(
    object
        facade
) :
    BaseArcController(
        facade
    )
{

    protected async Task<IActionResult> Invoke
    <
        TRequestArgs
    >(
        TRequestArgs args
    )
    {
        var identity =
            GetIdentity();

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
                        TRequestArgs
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
            GetIdentity();

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
                IExtendedMethodFacade extendedExecutionFacade =>
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
        ArcIdentity identity
    )
    {
        if (facade is IValidationFacade validationFacade)
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
        ArcIdentity identity
    )
    {
        if (facade is IExtendedValidationFacade
            <
                TRequestArgs
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

    private ArcIdentity GetIdentity()
    {
        var httpContextItems =
            HttpContext.Items;

        var isSuccess =
            httpContextItems
                .TryGetValue(
                    ArcIdentityConstants.ArcIdentity,
                    out var identity
                );

        if (isSuccess
            && identity is ArcIdentity arcIdentity)
        {
            return arcIdentity;
        }

        throw new();
    }
}