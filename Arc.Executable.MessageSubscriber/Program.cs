using System;

using Arc.Dependencies.RabbitMq.Implementations;
using Arc.Executable.MessageSubscriber.Implementations;

using static Arc.Dependencies.RabbitMq.Constants.ExchangeNameConstants;

var queueConnectionCreateDomainFacade =
    new QueueConnectionCreateDomainFacadeBuilder()
        .Build();

var channelQueueNameService =
    new ChannelQueueNameService();

var channelSubscribeService =
    new ChannelSubscribeService(
    channelQueueNameService
);

var publishSubscribeChannelService =
    new PublishSubscribeChannelService();

using var connection =
    queueConnectionCreateDomainFacade
        .Create();

var channel =
    await
        publishSubscribeChannelService
            .Create(
                connection,
                PushSubErrorLog
            );

var eventHandler =
    new EventHandlerBuilder()
        .Build();

await
    channelSubscribeService
        .Subscribe(
            channel,
            eventHandler
        );

Console
    .WriteLine(
    "Subscription successful"
);

Console
    .WriteLine(
    "To stop listen - press [enter]"
);

Console.ReadLine();


