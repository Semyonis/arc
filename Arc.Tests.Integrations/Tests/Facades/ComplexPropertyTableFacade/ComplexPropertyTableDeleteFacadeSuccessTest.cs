using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.Views.Admins.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ComplexPropertyTableFacade;

public class ComplexPropertyTableDeleteFacadeSuccessTest
{
    [Fact]
    public async Task SuccessTest()
    {
        var factory =
            new Factory();

        var context =
            factory.Context;

        var complexPropertyDescriptionFirst =
            new ComplexPropertyDescription
            {
                Value = "description",
            };

        var complexPropertyDescriptionSecond =
            new ComplexPropertyDescription
            {
                Value = "description",
            };

        var complexPropertyDescriptionThird =
            new ComplexPropertyDescription
            {
                Value = "description",
            };

        var groupDescriptionFirst =
            new GroupDescription
            {
                Value = "description",
            };

        var groupDescriptionSecond =
            new GroupDescription
            {
                Value = "description",
            };

        var groupDescriptionThird =
            new GroupDescription
            {
                Value = "description",
            };

        var groupFirst =
            new Group
            {
                Name = "group",
                Description = groupDescriptionFirst,
            };

        var groupSecond =
            new Group
            {
                Name = "group",
                Description = groupDescriptionSecond,
            };

        var groupThird =
            new Group
            {
                Name = "group",
                Description = groupDescriptionThird,
            };

        var complexProperties =
            new[]
            {
                new ComplexProperty
                {
                    Id = 1,
                    Value = "First",
                    Description = complexPropertyDescriptionFirst,
                    Group = groupFirst,
                },
                new ComplexProperty
                {
                    Id = 2,
                    Value = "Second",
                    Description = complexPropertyDescriptionSecond,
                    Group = groupSecond,
                },
                new ComplexProperty
                {
                    Id = 3,
                    Value = "Third",
                    Description = complexPropertyDescriptionThird,
                    Group = groupThird,
                },
            };

        context
            .AddEntities(
                complexProperties
            );

        var facade =
            factory
                .DependencyFactory
                .GetImplementation<IComplexPropertiesTableDeleteFacade>();

        var adminIdentity =
            new AdminIdentity(
                1
            );

        var ids =
            new[]
            {
                1,
                2,
                3,
            };

        var result =
            await
                facade
                    .Execute(
                        ids,
                        adminIdentity
                    );

        var response =
            result.ValidateSuccess<TableActionResultResponse>();

        response
            .ChangedEntitiesCount
            .Should()
            .Be(
                3
            );
    }
}