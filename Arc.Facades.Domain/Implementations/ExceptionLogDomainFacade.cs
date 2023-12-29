using Arc.Dependencies.Json.Interfaces;
using Arc.Dependencies.Logger.Interfaces;
using Arc.Dependencies.RabbitMq.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.ConfigurationSettings.Interfaces;
using Arc.Infrastructure.Exceptions.Models;

using Microsoft.Extensions.Logging;

namespace Arc.Facades.Domain.Implementations;

public sealed class ExceptionLogDomainFacade(
    ILoggerDecorator
        logger,
    IPublishSubscribeChannelService
        publishSubscribeChannelService,
    IRabbitMqSettingsFactory
        rabbitMqSettingsFactory,
    IQueueConnectionService
        queueConnectionService,
    IChannelPublishService
        channelPublishService,
    ISerializationDecorator
        serializationDecorator
) :
    IExceptionLogDomainFacade
{
    private const int DefaultRabbitMqPort =
        5672;

    private const string ErrorLog =
        "ErrorLog";

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
                    args.ErrorData
                );
        }
    }

    private async Task PublishExceptionIntoLogQueue(
        IDictionary<string, object> errorData
    )
    {
        var settings =
            rabbitMqSettingsFactory
                .GetSettings();

        var toNullableInteger =
            settings
                .Port
                .ParseToNullableInteger();

        var integerPort =
            toNullableInteger
            ?? DefaultRabbitMqPort;

        var connection =
            queueConnectionService
                .CreateInstance(
                    settings.Host,
                    integerPort
                );

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

        await
            channelPublishService
                .Publish(
                    chanel,
                    queueMessage
                );
    }

    private void HandleServerException(
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