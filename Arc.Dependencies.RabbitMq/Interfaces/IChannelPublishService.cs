using Arc.Dependencies.RabbitMq.Model;

namespace Arc.Dependencies.RabbitMq.Interfaces;

public interface IChannelPublishService
{
    Task Publish(
        PublishSubscribeChannel channel,
        string message
    );
}