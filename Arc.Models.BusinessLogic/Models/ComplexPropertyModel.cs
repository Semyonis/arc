namespace Arc.Models.BusinessLogic.Models;

public sealed record ComplexPropertyModel(
    int Id,
    string Value,
    GroupModel Group,
    DescriptionModel Description
) : IWithIdentifier,
    IWithValue;