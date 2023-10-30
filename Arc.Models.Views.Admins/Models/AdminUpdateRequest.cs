namespace Arc.Models.Views.Admins.Models;

public sealed record AdminUpdateRequest(
    int Id,
    string FirstName,
    string LastName
);