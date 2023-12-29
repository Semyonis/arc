using System.Text;

using Arc.Dependencies.RabbitMq.Interfaces;
using Arc.Dependencies.RabbitMq.Model;

using RabbitMQ.Client.Events;

namespace Arc.Dependencies.RabbitMq.Implementations;

public sealed  class ChannelSubscribeService(
    IChannelQueueNameService
        channelQueueNameService
) :
    IChannelSubscribeService
{
    public async Task Subscribe(
        PublishSubscribeChannel channel
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
                .QueueBindAsync(
                    queue: queueName,
                    exchange: channel.exchange,
                    routingKey: string.Empty,
                    arguments: default
                );

        var consumer =
            new EventingBasicConsumer(
                channel.channel
            );

        consumer.Received += (
            model,
            ea
        ) =>
        {
            byte[] body = ea.Body.ToArray();

            var message = Encoding.UTF8.GetString(
                body
            );

        };

        await
            channel
                .channel
                .BasicConsumeAsync(
                    queue: queueName,
                    autoAck: true,
                    consumerTag: string.Empty,
                    noLocal: default,
                    exclusive: default,
                    arguments: default,
                    consumer: consumer
                );
    }
}