// ReSharper disable NotAccessedPositionalProperty.Global

namespace Arc.Models.Views.Users.Models;

public sealed record UserResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email
);