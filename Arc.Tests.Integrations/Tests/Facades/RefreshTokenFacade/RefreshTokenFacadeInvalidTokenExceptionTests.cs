using Arc.Database.Entities.Models;
using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.RefreshTokenFacade;

public sealed class RefreshTokenFacadeInvalidTokenExceptionTests
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

        var modelRefresh =
            new RefreshTokenRequest(
                "InvalidToken"
            );

        var refreshTokenFacade =
            factory
                .DependencyFactory
                .GetImplementation<IRefreshTokenFacade>();

        await
            refreshTokenFacade
                .Execute(
                    modelRefresh
                )
                .ValidateFail(
                    ErrorCodeConstants.InvalidToken
                );
    }
}