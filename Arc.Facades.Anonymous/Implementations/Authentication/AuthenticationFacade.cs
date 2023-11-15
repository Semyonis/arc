using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Authentication;

public sealed class AuthenticationFacade(
        IUserManagerService
            userManagerService,
        ISignInManagerDecorator
            signInManagerDecorator,
        IResponsesDomainFacade
            internalFacade,
        IActorsReadRepository
            actorsReadRepository,
        IAuthenticationTokensCreateDomainFacade
            authenticationTokensCreateDomainFacade,
        IWrongCredentialsExceptionDescriptor
            wrongCredentialsExceptionDescriptor
    )
    :
        IAuthenticationFacade
{
    public async Task<Response> Execute(
        LoginRequest model
    )
    {
        (
            var email,
            var password
        ) = model;

        var identity =
            await
                userManagerService
                    .FindByEmail(
                        email
                    );

        if (identity == default)
        {
            throw
                wrongCredentialsExceptionDescriptor
                    .CreateException();
        }

        var signInResult =
            await
                signInManagerDecorator
                    .PasswordSignIn(
                        identity.UserName!,
                        password
                    );

        if (signInResult is not { Succeeded: true, })
        {
            throw
                wrongCredentialsExceptionDescriptor
                    .CreateException();
        }

        var actor =
            await
                GetActor(
                    email
                );

        var args =
            new AuthenticationTokensCreateDomainFacadeArgs(
                identity,
                actor
            );

        var authenticationModel =
            await
                authenticationTokensCreateDomainFacade
                    .CreateTokens(
                        args
                    );

        var response =
            new AuthenticationResponse(
                authenticationModel.TokenAccess,
                authenticationModel.TokenRefresh,
                authenticationModel.ExpirationAccess
            );

        return
            internalFacade
                .CreateOkResponse(
                    response
                );
    }

    private async Task<ActorModel> GetActor(
        string email
    )
    {
        var actor =
            await
                actorsReadRepository
                    .GetByEmail(
                        email
                    );

        var actorTypes =
            Enum
                .Parse<ActorTypes>(
                    actor!.Discriminator
                );

        return
            new(
                actor.Id,
                actorTypes
            );
    }
}