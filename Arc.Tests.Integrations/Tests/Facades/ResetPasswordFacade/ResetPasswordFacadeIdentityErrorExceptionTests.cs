using Arc.Database.Entities.Models;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Infrastructure.Exceptions.Models;
using Arc.Models.Views.Anonymous.Models;
using Arc.Platform.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using NSubstitute.ExceptionExtensions;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ResetPasswordFacade;

public sealed class ResetPasswordFacadeIdentityErrorExceptionTests
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

        var userPasswordManagerService =
            factory
                .DependencyFactory
                .GetImplementation<IUserPasswordManagerService>();

        userPasswordManagerService
            .ResetPassword(
                Arg.Any<IdentityUser>(),
                Code,
                Password
            )
            .Throws(
                new ServerException(
                    new(
                        ErrorCodeConstants.IdentityError
                    )
                )
            );

        var request =
            new ResetPasswordRequest(
                Email,
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
                .ValidateFail(
                    ErrorCodeConstants.IdentityError
                );
    }
}