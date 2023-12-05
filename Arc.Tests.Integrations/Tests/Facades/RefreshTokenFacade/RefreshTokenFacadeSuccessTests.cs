using Arc.Database.Entities.Models;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.RefreshTokenFacade;

public sealed class RefreshTokenFacadeSuccessTests
{
    [Fact]
    public async Task SuccessTest()
    {
        var factory =
            new Factory();

        var context =
            factory.Context;

        var user =
            new User
            {
                Email = "email@domain.com",
                FirstName = "First Name",
                LastName = "Last Name",
            };

        context
            .AddEntity(
                user
            );

        var user1 =
            new User
            {
                Email = "email@domain.com",
                FirstName = "First Name",
                LastName = "Last Name",
            };

        context
            .AddEntity(
                user1
            );

        var modelLogin =
            new LoginRequest(
                user1.Email,
                "Password"
            );

        var identityUser1 =
            new IdentityUser
            {
                UserName = user1.Email,
                EmailConfirmed = true,
            };

        var userManagerService =
            factory
                .DependencyFactory
                .GetImplementation<IUserManagerService>();

        userManagerService
            .FindByEmail(
                identityUser1.UserName
            )!
            .Returns(
                Task.FromResult(
                    identityUser1
                )
            );

        var signInManagerDecorator =
            factory
                .DependencyFactory
                .GetImplementation<ISignInManagerDecorator>();

        signInManagerDecorator
            .PasswordSignIn(
                Arg.Any<string>(),
                Arg.Any<string>()
            )
            .Returns(
                Task.FromResult(
                    SignInResult.Success
                )
            );

        var userManager =
            factory
                .DependencyFactory
                .GetImplementation<UserManager<IdentityUser>>();

        var authenticationFacade =
            factory
                .DependencyFactory
                .GetImplementation<IAuthenticationFacade>();

        var result1 =
            await
                authenticationFacade
                    .Execute(
                        modelLogin
                    );

        var responseDataModel1 =
            result1.ValidateSuccess<AuthenticationResponse>();

        var loginUserSuccessTest =
            responseDataModel1
                .TokenRefresh;

        var identityUser =
            new IdentityUser
            {
                UserName = user.Email,
                EmailConfirmed = true,
            };

        userManager
            .FindByEmailAsync(
                user.Email
            )!
            .Returns(
                Task.FromResult(
                    identityUser
                )
            );

        var userTokenManagerService =
            factory
                .DependencyFactory
                .GetImplementation<IUserTokenManagerService>();

        userTokenManagerService
            .GetAuthenticationToken(
                Arg.Any<IdentityUser>()
            )!
            .Returns(
                Task.FromResult(
                    loginUserSuccessTest
                )
            );

        var request =
            new RefreshTokenRequest(
                loginUserSuccessTest
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IRefreshTokenFacade>();

        await
            facade
                .Execute(
                    request
                )
                .ValidateSuccess<AuthenticationResponse>();
    }
}