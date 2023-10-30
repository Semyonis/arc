namespace Arc.Models.BusinessLogic.Models.Identities;

public abstract record BaseIdentity(
    int Id,
    ActorTypes Type
);