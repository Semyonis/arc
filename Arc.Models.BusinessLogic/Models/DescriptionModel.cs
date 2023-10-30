namespace Arc.Models.BusinessLogic.Models;

public sealed record DescriptionModel(
    int Id,
    string Value
) : IWithIdentifier,
    IWithValue;