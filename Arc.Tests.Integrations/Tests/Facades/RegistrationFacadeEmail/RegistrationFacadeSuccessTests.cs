using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.RegistrationFacadeEmail;

public sealed class RegistrationFacadeSuccessTests
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
            .AddEntities(
                user
            );

        const string Email =
            "some@domain.com";

        const string Password =
            "Password";

        var userManager =
            factory
                .DependencyFactory
                .GetImplementation<UserManager<IdentityUser>>();

        userManager
            .CreateAsync(
                Arg.Is<IdentityUser>(
                    entity =>
                        entity.Email
                        == Email
                ),
                Password
            )
            .Returns(
                Task.FromResult(
                    IdentityResult.Success
                )
            );

        userManager
            .GenerateEmailConfirmationTokenAsync(
                Arg.Is<IdentityUser>(
                    entity =>
                        entity.Email
                        == Email
                )
            )
            .Returns(
                Task.FromResult(
                    "confirm_code_for_send_user"
                )
            );

        userManager
            .FindByEmailAsync(
                Email
            )!
            .Returns(
                Task.FromResult(
                    (IdentityUser)null!
                )
            );

        var request =
            new CreateUserRequest(
                Email,
                "First Name",
                "Last Name",
                Password,
                Password
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
                .ValidateSuccess();
    }
}