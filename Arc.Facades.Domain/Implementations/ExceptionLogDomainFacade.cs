using System.Text;

using Arc.Dependencies.Json.Interfaces;
using Arc.Dependencies.Logger.Interfaces;
using Arc.Dependencies.RabbitMq.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Models;

using Microsoft.Extensions.Logging;

namespace Arc.Facades.Domain.Implementations;

public sealed class ExceptionLogDomainFacade(
    ILoggerDecorator
        logger,
    IPublishSubscribeChannelService
        publishSubscribeChannelService,
    IChannelPublishService
        channelPublishService,
    ISerializationDecorator
        serializationDecorator,
    IQueueConnectionCreateDomainFacade
        queueConnectionCreateDomainFacade
) :
    IExceptionLogDomainFacade
{
    private const string ErrorLog =
        "ErrorLog";

    private const string Errors =
        "Errors";

    private const string Stacktrace =
        "StackTrace";

    public async Task Log(
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
                errorData,
                serverException
            );
        }
        else
        {
            var message =
                serializationDecorator
                    .Serialize(
                        errorData
                    );

            logger
                .LogError(
                    exception,
                    message
                );

            await
                PublishExceptionIntoLogQueue(
                    errorData
                );
        }
    }

    private async Task PublishExceptionIntoLogQueue(
        IDictionary<string, object> errorData
    )
    {
        var connection =
            queueConnectionCreateDomainFacade
                .Create();

        var chanel =
            await
                publishSubscribeChannelService
                    .Create(
                        connection,
                        ErrorLog
                    );

        var queueMessage =
            serializationDecorator
                .Serialize(
                    errorData
                );

        var bytes =
            GetUtf8Bytes(
                queueMessage
            );

        await
            channelPublishService
                .Publish(
                    chanel,
                    bytes
                );
    }

    private static byte[] GetUtf8Bytes(
        string message
    ) =>
        Encoding
            .UTF8
            .GetBytes(
                message
            );

    private void HandleServerException(
        IDictionary<string, object> errorData,
        ServerException serverException
    )
    {
        errorData
            .Add(
                Errors,
                serverException.ExceptionInfo
            );

        errorData
            .Add(
                Stacktrace,
                serverException.StackTrace!
            );

        var message =
            serializationDecorator
                .Serialize(
                    errorData
                );

        logger
            .Log(
                LogLevel.Warning,
                message,
                serverException
            );
    }
}