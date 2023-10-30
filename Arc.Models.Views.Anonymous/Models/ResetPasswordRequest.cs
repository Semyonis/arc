using Arc.Infrastructure.Services.Attributes;

namespace Arc.Models.Views.Anonymous.Models;
#pragma warning disable CS8618
public sealed record ResetPasswordRequest(
    string Email,
    string Code,
    [property: DontNormalizeString]
    string Password,
    [property: DontNormalizeString]
    string PasswordConfirm
);