namespace Arc.Facades.Domain.Args;

public sealed record UserPasswordUpdateDomainFacadeArgs(
    string Email,
    string Password
);