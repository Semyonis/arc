namespace Arc.Models.Views.Common.Models;

public sealed record UserResponse(
    int Id,
    string FirstName,
    string LastName,
    string Email
);