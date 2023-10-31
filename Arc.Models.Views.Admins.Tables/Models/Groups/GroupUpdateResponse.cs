using Arc.Infrastructure.Common.Interfaces;
using Arc.Models.Views.Common.Models;

namespace Arc.Models.Views.Admins.Tables.Models.Groups;

public sealed record GroupUpdateResponse(
    int Id,
    string Name,
    DescriptionUpdateRequest Description
) :
    IWithIdentifier;