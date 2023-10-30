namespace Arc.Models.BusinessLogic.Models.Identities;

public sealed record AdminIdentity(
    int Id
) :
    BaseIdentity(
        Id,
        ActorTypes.Admin
    );