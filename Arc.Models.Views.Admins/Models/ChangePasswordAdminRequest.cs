using Arc.Infrastructure.Services.Attributes;

namespace Arc.Models.Views.Admins.Models;

public sealed record ChangePasswordAdminRequest(
    string Email,
    [property: DontNormalizeString]
    string Password,
    [property: DontNormalizeString]
    string PasswordConfirm
);