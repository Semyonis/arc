using Arc.Dependencies.RabbitMq.Interfaces;

using RabbitMQ.Client;

namespace Arc.Dependencies.RabbitMq.Implementations;

public sealed class QueueConnectionService :
    IQueueConnectionService
{
    private static IConnection? Connection;
    
    private static readonly object Mutex =
        new ();
    
    public IConnection CreateInstance(
        string hostName,
        int port
    )
    {
        var factory =
            new ConnectionFactory
        {
            HostName =
                hostName,
            Port =
                port,
        };

        if (Connection == default)
        {
            lock (Mutex)
            {
               Connection ??=
                    factory.CreateConnection();
            }
        }

        return
            Connection;
    }
}