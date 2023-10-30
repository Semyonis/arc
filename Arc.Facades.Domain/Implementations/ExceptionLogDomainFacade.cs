using System.Text.Json;
using System.Text.Json.Serialization;

using Arc.Dependencies.Logger.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Models;

using Microsoft.Extensions.Logging;

namespace Arc.Facades.Domain.Implementations;

public sealed class ExceptionLogDomainFacade :
    IExceptionLogDomainFacade
{
    private static readonly JsonSerializerOptions
        JsonSerializerOptions =
            new()
            {
                Converters =
                {
                    new JsonStringEnumConverter(
                        default,
                        false
                    ),
                },
            };

    public void Log(
        ExceptionLogDomainFacadeArgs args
    )
    {
        (
            var exception,
            var errorData
        ) = args;

        if (exception is ServerException serverException)
        {
            HandleServerException(
                _logger,
                errorData,
                serverException
            );
        }
        else
        {
            var message =
                JsonSerializer
                    .Serialize(
                        errorData,
                        JsonSerializerOptions
                    );

            _logger
                .LogError(
                    exception,
                    message
                );
        }
    }

    private static void HandleServerException(
        ILoggerDecorator logger,
        IDictionary<string, object> errorData,
        ServerException serverException
    )
    {
        errorData
            .Add(
                "Errors",
                serverException.ExceptionInfo
            );

        errorData
            .Add(
                "StackTrace",
                serverException.StackTrace!
            );

        var message =
            JsonSerializer
                .Serialize(
                    errorData,
                    JsonSerializerOptions
                );

        logger
            .Log(
                LogLevel.Warning,
                message,
                serverException
            );
    }

#region Constructor

    private readonly ILoggerDecorator
        _logger;

    public ExceptionLogDomainFacade(
        ILoggerDecorator
            logger
    ) =>
        _logger =
            logger;

#endregion
}