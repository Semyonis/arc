#pragma warning disable CS8618
namespace Arc.Infrastructure.ConfigurationSettings.Models;

public sealed record JwtSettings
{
    public string Site { get; init; }

    public string SigningKey { get; init; }

    public string ExpiryInMinutesAccess { get; init; } = "90";

    public string ExpiryInMinutesRefresh { get; init; } = "180";
}