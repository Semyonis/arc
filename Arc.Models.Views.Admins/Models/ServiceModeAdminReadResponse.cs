// ReSharper disable NotAccessedPositionalProperty.Global

namespace Arc.Models.Views.Admins.Models;

public sealed record ServiceModeAdminReadResponse(
    ServiceModeType Mode,
    DateTime ModeSettingDate,
    int AdminId,
    string AdminEmail
);