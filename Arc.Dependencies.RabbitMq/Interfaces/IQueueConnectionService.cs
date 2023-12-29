using RabbitMQ.Client;

namespace Arc.Dependencies.RabbitMq.Interfaces;

public interface IQueueConnectionService
{
    IConnection CreateInstance(
        string hostName,
        int port
    );
}