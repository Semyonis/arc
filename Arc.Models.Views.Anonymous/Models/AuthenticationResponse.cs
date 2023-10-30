using System;

namespace Arc.Models.Views.Anonymous.Models;

public sealed record AuthenticationResponse(
    string TokenAccess,
    string TokenRefresh,
    DateTime ExpirationAccess
);