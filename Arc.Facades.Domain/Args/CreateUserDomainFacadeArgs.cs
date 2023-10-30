namespace Arc.Facades.Domain.Args;

public sealed record CreateUserDomainFacadeArgs(
    string FirstName,
    string LastName,
    string Email,
    string Password
);