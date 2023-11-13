using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.AdminsUpdateAdminFacade;

public sealed class AdminsUpdateFacadeSuccessTests
{
    [Fact]
    public async Task SuccessTest()
    {
        var factory =
            new Factory();

        var context =
            factory.Context;

        var admin =
            new Admin
            {
                Email = "test@mail.ru",
                FirstName = "First Name",
                LastName = "Last Name",
                Discriminator = "Admin",
            };

        context
            .AddEntity(
                admin
            );

        var request =
            new AdminUpdateRequest(
                admin.Id,
                "New First Name",
                "New Last Name"
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IAdminsUpdateFacade>();

        await
            facade
                .Execute(
                    request
                )
                .ValidateSuccess();
    }
}