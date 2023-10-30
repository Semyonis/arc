// ReSharper disable NotAccessedPositionalProperty.Global

namespace Arc.Models.Views.Admins.Models;

public sealed record AdminResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email
);