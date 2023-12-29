using RabbitMQ.Client;

namespace Arc.Dependencies.RabbitMq.Model;

public sealed record PublishSubscribeChannel(
    IChannel channel,
    string exchange
) :
    IDisposable
{
    public void Dispose() =>
        channel.Dispose();
}