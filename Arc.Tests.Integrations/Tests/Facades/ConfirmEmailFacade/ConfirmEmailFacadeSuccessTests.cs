using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Models.Views.Anonymous.Models;
using Arc.Platform.Base.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ConfirmEmailFacade;

public sealed class ConfirmEmailFacadeSuccessTests
{
    [Fact]
    public async Task SuccessTest()
    {
        var factory =
            new Factory();

        var user =
            new IdentityUser
            {
                UserName =
                    "UserName",
            };

        const string UserId =
            "UserId";

        const string Code =
            "Code";

        var userManager =
            factory
                .DependencyFactory
                .GetImplementation<UserManager<IdentityUser>>();

        userManager
            .FindByIdAsync(
                UserId
            )!
            .Returns(
                Task.FromResult(
                    user
                )
            );

        userManager
            .ConfirmEmailAsync(
                Arg.Is<IdentityUser>(
                    entity =>
                        entity.UserName
                        == user.UserName
                ),
                Code
            )
            .Returns(
                Task.FromResult(
                    IdentityResult.Success
                )
            );

        var emailRequest =
            new ConfirmEmailRequest(
                UserId,
                Code
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IConfirmEmailFacade>();

        await
            facade
                .Execute(
                    emailRequest
                )
                .ValidateSuccess();
    }
}