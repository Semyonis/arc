using Arc.Models.Views.Common.Models;

namespace Arc.Models.Views.Admins.Tables.Models.Groups;

public sealed record GroupCreateRequest(
    string Title,
    string Name,
    DescriptionCreateRequest Description,
    ReferenceRequest Gene
);