using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;

using Microsoft.AspNetCore.Http;

namespace Arc.Middleware.Filters.Implementations;

public sealed class ExceptionFilter(
        IErrorResponseFacade
            errorResponseFacade,
        IExceptionLogDomainFacade
            internalFacade
    )
    :
        IExceptionFilter
{
    public void OnException(
        ExceptionContext context
    )
    {
        var traceId =
            Guid
                .NewGuid()
                .ToString();

        var httpContext =
            context.HttpContext;

        var exception =
            context.Exception;

        LogException(
            httpContext,
            exception,
            traceId
        );

        var result =
            errorResponseFacade
                .CreateErrorResponse(
                    exception,
                    traceId
                );

        context.Result =
            result;
    }

    private void LogException(
        HttpContext httpContext,
        Exception exception,
        string traceId
    )
    {
        var actorId =
            GetActorId(
                httpContext
            );

        var methodName =
            GetMethodName(
                httpContext
            );

        var errorData =
            GetErrorData(
                traceId,
                actorId,
                methodName
            );

        var args =
            new ExceptionLogDomainFacadeArgs(
                exception,
                errorData
            );

        internalFacade
            .Log(
                args
            );
    }

    private static Dictionary<string, object> GetErrorData(
        string traceId,
        string? actorId,
        string methodName
    ) =>
        new()
        {
            {
                "TraceId", traceId
            },
            {
                "ActorId", actorId!
            },
            {
                "MethodName", methodName
            },
        };

    private static string? GetActorId(
        HttpContext httpContext
    )
    {
        var httpContextUser =
            httpContext.User;

        var actorId =
            httpContextUser
                .FindFirst(
                    ClaimTypeConstants.ActorId
                );

        return
            actorId?.Value;
    }

    private static string GetMethodName(
        HttpContext httpContext
    )
    {
        var httpRequest =
            httpContext.Request;

        var method =
            httpRequest.Method;

        var path =
            httpRequest.Path;

        var queryString =
            httpRequest.QueryString;

        return
            $"{method} {path} {queryString}";
    }
}