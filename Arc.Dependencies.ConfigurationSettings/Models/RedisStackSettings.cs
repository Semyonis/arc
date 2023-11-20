#pragma warning disable CS8618
namespace Arc.Dependencies.ConfigurationSettings.Models;

public sealed record RedisStackSettings
{
    public string Host { get; init; }

    public string Port { get; init; }
}