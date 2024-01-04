using Arc.Database.Entities.Models;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;
using Arc.Platform.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.AuthenticationFacade;

public sealed class AuthenticationFacadeWrongCredentialsExceptionTests
{
    [Fact]
    public async Task ExceptionTest()
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

        var userManager =
            factory
                .DependencyFactory
                .GetImplementation<UserManager<IdentityUser>>();

        userManager
            .FindByEmailAsync(
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
                    SignInResult.Failed
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
                .ValidateFail(
                    ErrorCodeConstants.WrongCredentials
                );
    }
}