using Arc.Database.Entities.Models;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.AuthenticationFacade;

public sealed class AuthenticationFacadeSuccessTest
{
    [Fact]
    public async Task SuccessTest()
    {
        var factory =
            new Factory();

        var context =
            factory.Context;

        const string Email =
            "email@domain.com";

        var user =
            new User
            {
                Email = Email,
                FirstName = "First Name",
                LastName = "Last Name",
            };

        context
            .AddEntity(
                user
            );

        var identityUser =
            new IdentityUser
            {
                UserName = Email,
                EmailConfirmed = true,
            };

        var userManagerService =
            factory
                .DependencyFactory
                .GetImplementation<IUserManagerService>();

        userManagerService
            .FindByEmail(
                identityUser.UserName
            )!
            .Returns(
                Task.FromResult(
                    identityUser
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

        var request =
            new LoginRequest(
                Email,
                "Password"
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IAuthenticationFacade>();

        await
            facade
                .Execute(
                    request
                )
                .ValidateSuccess<AuthenticationResponse>();
    }
}