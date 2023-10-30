namespace Arc.Models.Views.Anonymous.Models;

public sealed record ConfirmEmailRequest(
    string UserId,
    string Code
);