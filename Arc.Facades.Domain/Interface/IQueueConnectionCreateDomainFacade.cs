using RabbitMQ.Client;

namespace Arc.Facades.Domain.Interface;

public interface IQueueConnectionCreateDomainFacade
{
    IConnection Create();
}