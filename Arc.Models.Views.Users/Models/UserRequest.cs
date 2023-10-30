namespace Arc.Models.Views.Users.Models;

public sealed record UserRequest(
    int Id,
    string FirstName,
    string LastName,
    string Email
);