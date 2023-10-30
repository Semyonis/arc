namespace Arc.Models.Views.Admins.Models;

public sealed record AdminPasswordRequest(
    int Id,
    string NewPassword
);