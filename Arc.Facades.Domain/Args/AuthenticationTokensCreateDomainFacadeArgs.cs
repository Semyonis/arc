using Arc.Models.BusinessLogic.Models;

using Microsoft.AspNetCore.Identity;

namespace Arc.Facades.Domain.Args;

public sealed record AuthenticationTokensCreateDomainFacadeArgs(
    IdentityUser Identity,
    ActorModel Actor
);