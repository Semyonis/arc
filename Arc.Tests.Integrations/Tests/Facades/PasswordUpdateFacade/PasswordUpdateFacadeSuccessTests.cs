using Arc.Facades.Users.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Users.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.PasswordUpdateFacade;

public sealed class PasswordUpdateFacadeSuccessTests
{
    [Fact]
    public async Task ChangePasswordSuccessTest()
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
            .AddEntities(
                user
            );

        const string CurrentPassword =
            "CurrentPassword";

        const string NewPassword =
            "NewPassword";

        var identity =
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
                    identity
                )
            );

        userManager
            .ChangePasswordAsync(
                Arg.Is<IdentityUser>(
                    entity =>
                        entity.UserName
                        == user.Email
                ),
                CurrentPassword,
                NewPassword
            )
            .Returns(
                Task.FromResult(
                    IdentityResult.Success
                )
            );

        var userIdentity =
            new UserIdentity(
                user.Id
            );

        var request =
            new ChangePasswordRequest(
                CurrentPassword,
                NewPassword,
                NewPassword
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IPasswordUpdateFacade>();

        await
            facade
                .Execute(
                    request,
                    userIdentity
                )
                .ValidateSuccess();
    }
}