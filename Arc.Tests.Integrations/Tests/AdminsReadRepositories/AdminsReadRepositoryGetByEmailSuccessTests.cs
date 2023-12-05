using System.Collections.Generic;

using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Xunit;

namespace Arc.Tests.Integrations.Tests.AdminsReadRepositories;

public class AdminsReadRepositoryGetByEmailSuccessTests
{
    [Fact]
    public async Task SuccessTest()
    {
        var factory =
            new Factory();

        var context =
            factory.Context;

        const string HarrisonGmailCom =
            "Harrison@gmail.com";

        const string WrongHarrisonGmailCom =
            "harrison@gmail.com";

        var admins =
            new List<Admin>
            {
                new()
                {
                    Email = "Martin@domain.com",
                    FirstName = "Martin",
                    LastName = "Kruger",
                },
                new()
                {
                    Email = WrongHarrisonGmailCom,
                    FirstName = "Victor",
                    LastName = "Nitmanov",
                },
                new()
                {
                    Email = HarrisonGmailCom,
                    FirstName = "Kutma",
                    LastName = "Harrison",
                },
            };

        context
            .AddEntities(
                admins
            );

        var adminsReadRepository =
            factory
                .DependencyFactory
                .GetImplementation<IAdminsReadRepository>();

        var adminByEmail =
            await
                adminsReadRepository
                    .GetByEmail(
                        HarrisonGmailCom
                    );

        adminByEmail
            .Should()
            .NotBeNull();

        adminByEmail!
            .Email
            .Should()
            .Be(
                HarrisonGmailCom
            );
    }
}