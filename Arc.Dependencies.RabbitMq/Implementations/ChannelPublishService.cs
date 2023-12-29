using System.Text;

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
        string message
    )
    {
        var queueName =
            await
                channelQueueNameService
                    .GetQueueName(
                        channel
                    );

        var body =
            GetUtf8Bytes(
                message
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

    private static byte[] GetUtf8Bytes(
        string message
    ) =>
        Encoding
            .UTF8
            .GetBytes(
                message
            );
}