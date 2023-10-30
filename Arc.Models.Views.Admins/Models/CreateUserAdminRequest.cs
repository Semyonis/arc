using Arc.Infrastructure.Services.Attributes;

#pragma warning disable CS8618

namespace Arc.Models.Views.Admins.Models;

public sealed record CreateUserAdminRequest(
    string FirstName,
    string LastName,
    string Email,
    [property: DontNormalizeString]
    string Password
);