namespace Arc.Facades.Domain.Args;

public sealed record UserUpdateDomainFacadeArgs(
    int Id,
    string FirstName,
    string LastName
);