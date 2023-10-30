using Arc.Infrastructure.Common.Interfaces;

namespace Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

public sealed record SimplePropertyUpdateRequest(
    int Id,
    string Value
) :
    IWithIdentifier;