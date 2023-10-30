namespace Arc.Facades.Domain.Args;

public sealed record AdminUpdateDomainFacadeArgs(
    int Id,
    string FirstName,
    string LastName
);