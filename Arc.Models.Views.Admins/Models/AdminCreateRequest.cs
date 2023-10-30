namespace Arc.Models.Views.Admins.Models;

public sealed record AdminCreateRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password
);