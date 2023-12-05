using Arc.Database.Entities.Models;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ForgotPasswordFacade;

public sealed class ForgotPasswordFacadeSuccessTests
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

        const string Email =
            "test@email.ru";

        var identityUser =
            new IdentityUser
            {
                UserName = "UserName",
                EmailConfirmed = true,
            };

        var userManagerService =
            factory
                .DependencyFactory
                .GetImplementation<IUserManagerService>();

        userManagerService
            .FindByEmail(
                Email
            )!
            .Returns(
                Task.FromResult(
                    identityUser
                )
            );

        var request =
            new ForgotPasswordRequest(
                Email,
                string.Empty
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IForgotPasswordFacade>();

        await
            facade
                .Execute(
                    request
                )
                .ValidateSuccess();
    }
}