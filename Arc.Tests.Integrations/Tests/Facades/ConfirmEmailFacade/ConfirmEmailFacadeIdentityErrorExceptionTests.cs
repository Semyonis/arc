using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Infrastructure.Exceptions.Models;
using Arc.Models.Views.Anonymous.Models;
using Arc.Platform.Base.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using NSubstitute.ExceptionExtensions;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ConfirmEmailFacade;

public sealed class ConfirmEmailFacadeIdentityErrorExceptionTests
{
    [Fact]
    public async Task ExceptionTest()
    {
        var factory =
            new Factory();

        const string UserId =
            "same_user_id";

        const string Code =
            "same_user_code";

        var user =
            new IdentityUser
            {
                UserName = "UserName",
            };

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

        var userManagerService =
            factory
                .DependencyFactory
                .GetImplementation<IUserManagerService>();

        userManagerService
            .ConfirmEmail(
                Arg.Any<string>(),
                Code
            )
            .Throws(
                new ServerException(
                    new(
                        ErrorCodeConstants.IdentityError
                    )
                )
            );

        var request =
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
                    request
                )
                .ValidateFail(
                    ErrorCodeConstants.IdentityError
                );
    }
}