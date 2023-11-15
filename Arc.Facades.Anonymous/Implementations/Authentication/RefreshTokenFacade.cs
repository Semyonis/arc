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

public sealed class RefreshTokenFacade(
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
) : IRefreshTokenFacade
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
                userManagerService
                    .FindByEmail(
                        email!
                    );

        if (identity == default)
        {
            throw
                userNotFoundExceptionDescriptor.CreateException();
        }

        var refreshToken =
            await
                userTokenManagerService
                    .GetAuthenticationToken(
                        identity
                    );

        if (refreshToken != model.TokenRefresh)
        {
            throw
                invalidTokenExceptionDescriptor
                    .CreateException();
        }

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
                badDataExceptionDescriptor.CreateException();
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
            invalidTokenExceptionDescriptor
                .CreateException();
    }

    private void ValidateToken(
        SecurityToken token
    )
    {
        if (token == default)
        {
            throw
                invalidTokenExceptionDescriptor
                    .CreateException();
        }

        if (token.ValidTo < DateTime.UtcNow)
        {
            throw
                invalidTokenExceptionDescriptor
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
}