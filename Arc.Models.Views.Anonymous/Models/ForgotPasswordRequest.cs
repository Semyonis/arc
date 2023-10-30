namespace Arc.Models.Views.Anonymous.Models;

public sealed record ForgotPasswordRequest(
    string Email,
    string Url
);