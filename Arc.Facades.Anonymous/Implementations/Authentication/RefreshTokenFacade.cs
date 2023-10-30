using System.IdentityModel.Tokens.Jwt;

using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

using Microsoft.IdentityModel.Tokens;

namespace Arc.Facades.Anonymous.Implementations.Authentication;

public sealed class RefreshTokenFacade :
    IRefreshTokenFacade
{
    public async Task<Response> Execute(
        RefreshTokenRequest model
    )
    {
        var token =
            GetToken(
                model
            );

        ValidateToken(
            token
        );

        var email =
            GetActorEmail(
                token
            );

        var actor =
            GetActorModel(
                token
            );

        var identity =
            await
                _userManagerService
                    .FindByEmail(
                        email!
                    );

        if (identity == default)
        {
            throw
                _userNotFoundExceptionDescriptor.CreateException();
        }

        var refreshToken =
            await
                _userTokenManagerService
                    .GetAuthenticationToken(
                        identity
                    );

        if (refreshToken != model.TokenRefresh)
        {
            throw
                _invalidTokenExceptionDescriptor
                    .CreateException();
        }

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

    private JwtSecurityToken GetToken(
        RefreshTokenRequest request
    )
    {
        var handlerToken =
            new JwtSecurityTokenHandler();

        var hasNoToken =
            request
                .TokenRefresh
                .IsEmpty();

        if (hasNoToken)
        {
            throw
                _badDataExceptionDescriptor.CreateException();
        }

        var canReadToken =
            handlerToken
                .CanReadToken(
                    request.TokenRefresh
                );

        if (canReadToken)
        {
            return
                handlerToken
                    .ReadJwtToken(
                        request.TokenRefresh
                    );
        }

        throw
            _invalidTokenExceptionDescriptor
                .CreateException();
    }

    private void ValidateToken(
        SecurityToken token
    )
    {
        if (token == default)
        {
            throw
                _invalidTokenExceptionDescriptor
                    .CreateException();
        }

        if (token.ValidTo < DateTime.UtcNow)
        {
            throw
                _invalidTokenExceptionDescriptor
                    .CreateException();
        }
    }

    private static ActorModel GetActorModel(
        JwtSecurityToken token
    )
    {
        var actorId =
            GetActorId(
                token
            );

        var actorType =
            GetActorType(
                token
            );

        return
            new(
                actorId,
                actorType
            );
    }

    private static int GetActorId(
        JwtSecurityToken token
    )
    {
        var identifier =
            token
                .Claims
                .First(
                    claim =>
                        claim.Type
                        == ClaimTypeConstants.ActorId
                )
                .Value;

        var id =
            identifier.ParseToNullableInteger()
            ?? 0;

        return id;
    }

    private static ActorTypes GetActorType(
        JwtSecurityToken token
    )
    {
        var value = token
            .Claims
            .First(
                claim =>
                    claim.Type
                    == ClaimTypeConstants.ActorType
            )
            .Value;

        var type =
            Enum
                .Parse<ActorTypes>(
                    value
                );

        return type;
    }

    private static string? GetActorEmail(
        JwtSecurityToken token
    ) =>
        token
            .Claims
            .Where(
                claim =>
                    claim
                        .Type
                        .Contains(

                            //todo wat ?
                            "name"
                        )
            )
            .Select(
                claim =>
                    claim.Value
            )
            .SingleOrDefault();

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly IUserManagerService
        _userManagerService;

    private readonly IUserTokenManagerService
        _userTokenManagerService;

    private readonly IAuthenticationTokensCreateDomainFacade
        _authenticationTokensCreateDomainFacade;

    private readonly IInvalidTokenExceptionDescriptor
        _invalidTokenExceptionDescriptor;

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public RefreshTokenFacade(
        IUserManagerService
            userManagerService,
        IResponsesDomainFacade
            internalFacade,
        IUserTokenManagerService
            userTokenManagerService,
        IAuthenticationTokensCreateDomainFacade
            authenticationTokensCreateDomainFacade,
        IInvalidTokenExceptionDescriptor
            invalidTokenExceptionDescriptor,
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _userManagerService =
            userManagerService;

        _internalFacade =
            internalFacade;

        _userTokenManagerService =
            userTokenManagerService;

        _authenticationTokensCreateDomainFacade =
            authenticationTokensCreateDomainFacade;

        _invalidTokenExceptionDescriptor =
            invalidTokenExceptionDescriptor;

        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}