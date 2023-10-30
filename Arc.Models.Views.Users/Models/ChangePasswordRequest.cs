namespace Arc.Models.Views.Users.Models;

public sealed record ChangePasswordRequest(
    string CurrentPassword,
    string Password,
    string PasswordConfirm
);