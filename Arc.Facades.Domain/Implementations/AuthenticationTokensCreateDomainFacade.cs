using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Arc.Dependencies.ConfigurationSettings.Interfaces;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Models.BusinessLogic.Models;

using Microsoft.IdentityModel.Tokens;

namespace Arc.Facades.Domain.Implementations;

public sealed class AuthenticationTokensCreateDomainFacade(
        IUserManagerDecorator
            userRoleManagerService,
        IUserTokenManagerService
            userTokenManagerService,
        IJwtSettingsFactory
            jwtSettingsFactory,
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor
    )
    :
        IAuthenticationTokensCreateDomainFacade
{
    public async Task<AuthenticationModel> CreateTokens(
        AuthenticationTokensCreateDomainFacadeArgs args
    )
    {
        (
            var identity,
            var actor
        ) = args;

        var jwtSettings =
            jwtSettingsFactory
                .GetSettings();

        var bytes =
            Encoding
                .UTF8
                .GetBytes(
                    jwtSettings.SigningKey
                );

        var signinKey =
            new SymmetricSecurityKey(
                bytes
            );

        var isAccessSuccess =
            int
                .TryParse(
                    jwtSettings.ExpiryInMinutesAccess,
                    out var expiryInMinutesAccess
                );

        if (!isAccessSuccess)
        {
            throw
                badDataExceptionDescriptor.CreateException();
        }

        var isRefreshSuccess =
            int
                .TryParse(
                    jwtSettings.ExpiryInMinutesRefresh,
                    out var expiryInMinutesRefresh
                );

        if (!isRefreshSuccess)
        {
            throw
                badDataExceptionDescriptor.CreateException();
        }

        var roles =
            await
                userRoleManagerService
                    .GetRolesAsync(
                        identity
                    );

        (
            var id,
            var userTypes
        ) = actor;

        var claims =
            new List<Claim>
            {
                new(
                    ClaimsIdentity.DefaultNameClaimType,
                    identity.UserName!
                ),
                new(
                    ClaimTypeConstants.ActorId,
                    id.ToString()
                ),
                new(
                    ClaimTypeConstants.ActorType,
                    userTypes.ToString()
                ),
            };

        var expires =
            DateTime
                .UtcNow
                .AddMinutes(
                    expiryInMinutesRefresh
                );

        var signingCredentials =
            new SigningCredentials(
                signinKey,
                SecurityAlgorithms.HmacSha256
            );

        var tokenRefresh =
            new JwtSecurityToken(
                jwtSettings.Site,
                jwtSettings.Site,
                claims,
                DateTime.UtcNow,
                expires,
                signingCredentials
            );

        foreach (var role in roles)
        {
            var claim =
                new Claim(
                    ClaimsIdentity.DefaultRoleClaimType,
                    role
                );

            claims
                .Add(
                    claim
                );
        }

        var addMinutes =
            DateTime
                .UtcNow
                .AddMinutes(
                    expiryInMinutesAccess
                );

        var tokenAccess =
            new JwtSecurityToken(
                jwtSettings.Site,
                jwtSettings.Site,
                claims,
                DateTime.UtcNow,
                addMinutes,
                signingCredentials
            );

        var handlerToken =
            new JwtSecurityTokenHandler();

        var tokenAccessString =
            handlerToken
                .WriteToken(
                    tokenAccess
                );

        var tokenRefreshString =
            handlerToken
                .WriteToken(
                    tokenRefresh
                );

        var resultAuth =
            new AuthenticationModel(
                tokenAccessString,
                tokenRefreshString,
                tokenAccess.ValidTo
            );

        await
            userTokenManagerService
                .RefreshAuthenticationToken(
                    identity,
                    resultAuth.TokenRefresh
                );

        return
            resultAuth;
    }
}