namespace Arc.Models.BusinessLogic.Models.Identities;

public sealed record UserIdentity(
    int Id
) : BaseIdentity(
    Id,
    ActorTypes.User
);