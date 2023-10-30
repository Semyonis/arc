namespace Arc.Models.BusinessLogic.Models;

public sealed record ServiceModeModel(
    ServiceModeType Mode,
    DateTime ModeSettingDate,
    int AdminId,
    string AdminEmail
);