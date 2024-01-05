using Arc.Dependencies.RabbitMq.Model;

using RabbitMQ.Client.Events;

namespace Arc.Dependencies.RabbitMq.Interfaces;

public interface IChannelSubscribeService
{
    Task Subscribe(
        PublishSubscribeChannel channel,
        EventHandler<BasicDeliverEventArgs> handler
    );
}