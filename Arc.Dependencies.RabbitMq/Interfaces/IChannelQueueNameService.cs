using Arc.Dependencies.RabbitMq.Model;

namespace Arc.Dependencies.RabbitMq.Interfaces;

public interface IChannelQueueNameService
{
    Task<string> GetQueueName(
        PublishSubscribeChannel channel
    );
}