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

public sealed class AuthenticationFacade :
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
                _userManagerService
                    .FindByEmail(
                        email
                    );

        if (identity == default)
        {
            throw
                _wrongCredentialsExceptionDescriptor
                    .CreateException();
        }

        var signInResult =
            await
                _signInManagerDecorator
                    .PasswordSignIn(
                        identity.UserName!,
                        password
                    );

        if (signInResult is not { Succeeded: true, })
        {
            throw
                _wrongCredentialsExceptionDescriptor
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
                _authenticationTokensCreateDomainFacade
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
            _internalFacade
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
                _actorsReadRepository
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

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly ISignInManagerDecorator
        _signInManagerDecorator;

    private readonly IUserManagerService
        _userManagerService;

    private readonly IActorsReadRepository
        _actorsReadRepository;

    private readonly IAuthenticationTokensCreateDomainFacade
        _authenticationTokensCreateDomainFacade;

    private readonly IWrongCredentialsExceptionDescriptor
        _wrongCredentialsExceptionDescriptor;

    public AuthenticationFacade(
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
    {
        _userManagerService =
            userManagerService;

        _signInManagerDecorator =
            signInManagerDecorator;

        _internalFacade =
            internalFacade;

        _actorsReadRepository =
            actorsReadRepository;

        _authenticationTokensCreateDomainFacade =
            authenticationTokensCreateDomainFacade;

        _wrongCredentialsExceptionDescriptor =
            wrongCredentialsExceptionDescriptor;
    }

#endregion
}