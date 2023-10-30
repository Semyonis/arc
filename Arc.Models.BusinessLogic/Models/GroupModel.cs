namespace Arc.Models.BusinessLogic.Models;

public sealed record GroupModel(
    int Id,
    string Name,
    DescriptionModel Description
) :
    IWithIdentifier,
    IWithName;