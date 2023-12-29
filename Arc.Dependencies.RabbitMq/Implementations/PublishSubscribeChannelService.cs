using Arc.Dependencies.RabbitMq.Interfaces;
using Arc.Dependencies.RabbitMq.Model;

using RabbitMQ.Client;

namespace Arc.Dependencies.RabbitMq.Implementations;

public sealed class PublishSubscribeChannelService :
    IPublishSubscribeChannelService
{
    public async Task<PublishSubscribeChannel> Create(
        IConnection connection,
        string exchange
    )
    {
        var channel =
            await
                connection.CreateChannelAsync();

        await
            channel
                .ExchangeDeclareAsync(
                    exchange: exchange,
                    type: ExchangeType.Fanout
                );

        return
            new(
                channel,
                exchange
            );
    }
}