namespace Arc.Models.BusinessLogic.Models;

public sealed record AuthenticationModel(
    string TokenAccess,
    string TokenRefresh,
    DateTime ExpirationAccess
);