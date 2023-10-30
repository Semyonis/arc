using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Exceptions.Interfaces.Services;
using Arc.Infrastructure.Exceptions.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Facades.Domain.Filters.Implementations;

public sealed class ErrorResponseFacade :
    IErrorResponseFacade
{
    public IActionResult CreateErrorResponse(
        Exception exception,
        string traceId
    )
    {
        var responseCode =
            GetResponseCode(
                exception
            );

        var errorResponse =
            _internalErrorsContainerService
                .GetErrorsContainer(
                    exception,
                    traceId
                );

        return
            new ObjectResult(
                errorResponse
            )
            {
                StatusCode =
                    responseCode,
            };
    }

    private static int GetResponseCode(
        Exception exception
    ) =>
        exception switch
        {
            ServerException serverException =>
                serverException.ResponseCode,
            _ =>
                HttpResponseCodeConstants.ServerError,
        };

#region Constructor

    private readonly
        IDomainErrorsContainerService
        _internalErrorsContainerService;

    public ErrorResponseFacade(
        IDomainErrorsContainerService
            internalErrorsContainerService
    ) =>
        _internalErrorsContainerService =
            internalErrorsContainerService;

#endregion
}