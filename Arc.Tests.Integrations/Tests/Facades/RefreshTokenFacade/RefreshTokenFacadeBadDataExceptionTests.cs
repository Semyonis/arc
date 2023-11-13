using Arc.Facades.Anonymous.Interfaces.Authentication;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Anonymous.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.RefreshTokenFacade;

public sealed class RefreshTokenFacadeBadDataExceptionTests
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

        var request =
            new RefreshTokenRequest(
                string.Empty
            );

        await
            factory
                .DependencyFactory
                .GetImplementation<IRefreshTokenFacade>()
                .Execute(
                    request
                )
                .ValidateFail(
                    ErrorCodeConstants.BadData
                );
    }
}