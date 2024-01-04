using Arc.Database.Entities.Models;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;
using Arc.Platform.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ForgotPasswordFacade;

public sealed class ForgotPasswordFacadeUserNotFoundExceptionTests
{
    [Fact]
    public async Task ExceptionTest()
    {
        var factory =
            new Factory();

        var context =
            factory.Context;

        var user =
            new User
            {
                Email = "email@domain.com",
                FirstName = "_firstName",
                LastName = "_lastName",
            };

        context
            .AddEntity(
                user
            );

        const string Email =
            "email@email.ru";

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
                    (IdentityUser)null!
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
                .ValidateFail(
                    ErrorCodeConstants.UserNotFound
                );
    }
}