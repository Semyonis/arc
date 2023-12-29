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
        exceptionLogDomainFacade
) : IAsyncExceptionFilter
{
    private const string Anonymous =
        "anonymous";

    public async Task OnExceptionAsync(
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

        var args =
            GetExceptionLogArgs(
                httpContext,
                exception,
                traceId
            );

        await
            exceptionLogDomainFacade
                .Log(
                    args
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

    private static ExceptionLogDomainFacadeArgs GetExceptionLogArgs(
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
            GetMethodInfo(
                httpContext
            );

        var errorData =
            GetErrorData(
                traceId,
                actorId,
                methodName
            );

        return
            new(
                exception,
                errorData
            );
    }

    private static Dictionary<string, object> GetErrorData(
        string traceId,
        string actorId,
        string methodInfo
    ) =>
        new()
        {
            {
                "TraceId", traceId
            },
            {
                "ActorId", actorId
            },
            {
                "MethodInfo", methodInfo
            },
        };

    private static string GetActorId(
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

        var actorIdValue =
            actorId?
                .Value
            ?? Anonymous;

        return
            actorIdValue;
    }

    private static string GetMethodInfo(
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

        var methodInfo =
            $"{method} {path} {queryString}";

        return
            methodInfo;
    }
}