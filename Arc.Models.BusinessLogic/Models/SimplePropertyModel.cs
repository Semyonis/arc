namespace Arc.Models.BusinessLogic.Models;

public sealed record SimplePropertyModel(
    int Id,
    string Value
) :
    IWithIdentifier,
    IWithValue;