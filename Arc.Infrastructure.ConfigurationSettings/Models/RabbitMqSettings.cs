#pragma warning disable CS8618
namespace Arc.Infrastructure.ConfigurationSettings.Models;

public sealed record RabbitMqSettings
{
    public string Host { get; init; }

    public string Port { get; init; }
}