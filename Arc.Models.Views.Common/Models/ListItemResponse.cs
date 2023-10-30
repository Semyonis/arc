using Arc.Infrastructure.Common.Interfaces;

namespace Arc.Models.Views.Common.Models;

public sealed record ListItemResponse(
    int Id,
    string Value
) :
    IWithIdentifier,
    IWithValue;