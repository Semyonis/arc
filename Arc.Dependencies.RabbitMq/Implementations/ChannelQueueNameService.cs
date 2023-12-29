using Arc.Dependencies.RabbitMq.Interfaces;
using Arc.Dependencies.RabbitMq.Model;

using RabbitMQ.Client;

namespace Arc.Dependencies.RabbitMq.Implementations;

public sealed class ChannelQueueNameService :
  IChannelQueueNameService
{
  public async Task<string> GetQueueName(
    PublishSubscribeChannel channel
  )
  {
    var queueDeclare =
      await
        channel
          .channel
          .QueueDeclareAsync();

    return 
      queueDeclare.QueueName;
  }
}