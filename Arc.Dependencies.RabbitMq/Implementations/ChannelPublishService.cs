using Arc.Dependencies.RabbitMq.Interfaces;
using Arc.Dependencies.RabbitMq.Model;

using RabbitMQ.Client;

namespace Arc.Dependencies.RabbitMq.Implementations;

public sealed class ChannelPublishService :
    IChannelPublishService
{
    public async Task Publish(
        PublishSubscribeChannel channel,
        ReadOnlyMemory<byte> body
    )
    {
        await
            channel
                .channel
                .BasicPublishAsync(
                    exchange: channel.exchange,
                    routingKey: string.Empty,
                    body: body
                );
    }
}