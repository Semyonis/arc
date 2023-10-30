using Arc.Facades.Domain.Args;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Facades.Domain.Interface;

public interface IAuthenticationTokensCreateDomainFacade
{
    Task<AuthenticationModel> CreateTokens(
        AuthenticationTokensCreateDomainFacadeArgs args
    );
}