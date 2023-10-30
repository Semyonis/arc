using Arc.Models.Views.Admins.Tables.Models.Groups;
using Arc.Models.Views.Common.Models;

namespace Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

public sealed record ComplexPropertyReadResponse(
    int Id,
    string Name,
    DescriptionResponse Description,
    GroupReadResponse Group
);