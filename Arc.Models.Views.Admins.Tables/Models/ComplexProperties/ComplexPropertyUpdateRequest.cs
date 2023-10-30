using Arc.Infrastructure.Common.Interfaces;
using Arc.Models.Views.Common.Models;

namespace Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

public sealed record ComplexPropertyUpdateRequest(
    int Id,
    string Name,
    DescriptionUpdateRequest Description,
    ReferenceRequest Group
) :
    IWithIdentifier;