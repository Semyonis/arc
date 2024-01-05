using Arc.Dependencies.RabbitMq.Interfaces;
using Arc.Dependencies.RabbitMq.Model;

using RabbitMQ.Client;

namespace Arc.Dependencies.RabbitMq.Implementations;

public sealed class ChannelPublishService(
    IChannelQueueNameService
        channelQueueNameService
) :
    IChannelPublishService
{
    public async Task Publish(
        PublishSubscribeChannel channel,
        ReadOnlyMemory<byte> body
    )
    {
        var queueName =
            await
                channelQueueNameService
                    .GetQueueName(
                        channel
                    );

        await
            channel
                .channel
                .BasicPublishAsync(
                    exchange: queueName,
                    routingKey: string.Empty,
                    body: body
                );
    }
}