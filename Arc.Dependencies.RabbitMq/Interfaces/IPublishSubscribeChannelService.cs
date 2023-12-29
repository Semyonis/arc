using Arc.Dependencies.RabbitMq.Model;

using RabbitMQ.Client;

namespace Arc.Dependencies.RabbitMq.Interfaces;

public interface IPublishSubscribeChannelService
{
    Task<PublishSubscribeChannel> Create(
        IConnection connection,
        string exchange
    );
}