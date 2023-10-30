using Arc.Infrastructure.Services.Attributes;

namespace Arc.Models.Views.Anonymous.Models;
#pragma warning disable CS8618
public sealed record LoginRequest(
    string UserName,
    [property: DontNormalizeString]
    string Password
);