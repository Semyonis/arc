using Arc.Dependencies.RabbitMq.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.ConfigurationSettings.Interfaces;

using RabbitMQ.Client;

namespace Arc.Facades.Domain.Implementations;

public sealed class QueueConnectionCreateDomainFacade(
    IRabbitMqSettingsFactory
        rabbitMqSettingsFactory,
    IQueueConnectionService
        queueConnectionService
) :
    IQueueConnectionCreateDomainFacade
{
    private const int DefaultRabbitMqPort =
        5672;

    public IConnection Create()
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

        return
            queueConnectionService
                .CreateInstance(
                    settings.Host,
                    integerPort
                );
    }
}