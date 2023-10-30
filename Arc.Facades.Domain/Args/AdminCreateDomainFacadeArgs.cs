namespace Arc.Facades.Domain.Args;

public sealed record AdminCreateDomainFacadeArgs(
    string FirstName,
    string LastName,
    string Email,
    string Password
);