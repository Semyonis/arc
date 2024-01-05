using Arc.Dependencies.RabbitMq.Implementations;
using Arc.Executable.Base;
using Arc.Facades.Domain.Implementations;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.ConfigurationSettings.Implementations;
using Arc.Infrastructure.ConfigurationSettings.Models;

namespace Arc.Executable.MessageSubscriber.Implementations;

internal sealed class QueueConnectionCreateDomainFacadeBuilder
{
    internal IQueueConnectionCreateDomainFacade Build()
    {
        const string RabbitMq =
            "RabbitMq";

        var rabbitMqSettings =
            new RabbitMqSettings();

        var optionsBuilder =
            new OptionsBuilder();

        var options =
            optionsBuilder
                .Build(
                    rabbitMqSettings,
                    RabbitMq
                );

        var rabbitMqSettingsFactory =
            new RabbitMqSettingsFactory(
                options
            );

        var queueConnectionService =
            new QueueConnectionService();

        return
            new QueueConnectionCreateDomainFacade(
                rabbitMqSettingsFactory,
                queueConnectionService
            );
    }
}