using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.RegistrationFacadeEmail;

public sealed class RegistrationFacadeEmailUsedByUserExceptionTests
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
            .FindByNameAsync(
                Email
            )!
            .Returns(
                Task.FromResult(
                    identityUser
                )
            );

        var request =
            new CreateUserRequest(
                Email,
                "First Name",
                "Last Name",
                "Password",
                "Password"
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IRegistrationFacade>();

        await
            facade
                .Execute(
                    request
                )
                .ValidateFail(
                    ErrorCodeConstants.EmailUsedByUser
                );
    }
}