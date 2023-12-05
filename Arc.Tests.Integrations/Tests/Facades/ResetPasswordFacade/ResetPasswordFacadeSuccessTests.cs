using Arc.Database.Entities.Models;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ResetPasswordFacade;

public sealed class ResetPasswordFacadeSuccessTests
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

        const string Code =
            "Code";

        const string Password =
            "Password";

        var userIdentity =
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
                Email
            )!
            .Returns(
                Task.FromResult(
                    userIdentity
                )
            );

        userManager
            .ResetPasswordAsync(
                Arg.Is<IdentityUser>(
                    entity =>
                        entity.UserName
                        == Email
                ),
                Code,
                Password
            )
            .Returns(
                Task.FromResult(
                    IdentityResult.Success
                )
            );

        var request =
            new ResetPasswordRequest(
                user.Email,
                Code,
                Password,
                Password
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IResetPasswordFacade>();

        await
            facade
                .Execute(
                    request
                )
                .ValidateSuccess();
    }
}