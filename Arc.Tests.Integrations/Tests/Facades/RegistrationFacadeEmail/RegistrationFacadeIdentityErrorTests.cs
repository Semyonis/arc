using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Infrastructure.Exceptions.Models;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Microsoft.AspNetCore.Identity;

using NSubstitute.ExceptionExtensions;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.RegistrationFacadeEmail;

public sealed class RegistrationFacadeIdentityErrorTests
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
                FirstName = "First Name",
                LastName = "Last Name",
            };

        context
            .AddEntity(
                user
            );

        var userManagerService =
            factory
                .DependencyFactory
                .GetImplementation<IUserManagerService>();

        userManagerService
            .Create(
                Arg.Any<IdentityUser>(),
                Arg.Any<string>()
            )
            .Throws(
                new ServerException(
                    new(
                        ErrorCodeConstants.IdentityError
                    )
                )
            );

        var request =
            new CreateUserRequest(
                "some@domain.com",
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
                    ErrorCodeConstants.IdentityError
                );
    }
}