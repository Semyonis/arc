using Arc.Infrastructure.Services.Attributes;

namespace Arc.Models.Views.Anonymous.Models;

public sealed record CreateUserRequest(
    string Email,
    string FirstName,
    string LastName,
    [property: DontNormalizeString]
    string Password,
    [property: DontNormalizeString]
    string PasswordConfirm
);