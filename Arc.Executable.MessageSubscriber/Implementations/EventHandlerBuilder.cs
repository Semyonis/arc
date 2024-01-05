using System;
using System.Text;

using RabbitMQ.Client.Events;

namespace Arc.Executable.MessageSubscriber.Implementations;

internal sealed class EventHandlerBuilder
{
    internal EventHandler<BasicDeliverEventArgs> Build() =>
        (
            sender,
            basicDeliverEventArgs
        ) =>
        {
            var body =
                basicDeliverEventArgs
                    .Body
                    .ToArray();

            var message =
                Encoding
                    .UTF8
                    .GetString(
                        body
                    );

            var format =
                $" {sender} {message}";

            Console
                .WriteLine(
                    format
                );
        };
}