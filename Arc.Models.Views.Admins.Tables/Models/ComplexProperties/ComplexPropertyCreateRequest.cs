using Arc.Models.Views.Common.Models;

namespace Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

public sealed record ComplexPropertyCreateRequest(
    string Name,
    DescriptionCreateRequest Description,
    ReferenceRequest Group
);