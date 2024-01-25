using System.Collections.Generic;

using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Extensions;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;
using Arc.Models.Views.Common.Models;
using Arc.Tests.Base.Extensions;
using Arc.Tests.Integrations.Extensions;
using Arc.Tests.Integrations.Factories;

using Xunit;

namespace Arc.Tests.Integrations.Tests.Facades.ComplexPropertyTableFacade;

public class ComplexPropertyTableFacadeContainsSuccessTest
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
                .GetImplementation<IComplexPropertiesTableFacade>();

        var filterPropertyRequestRequest =
            new FilterPropertyRequestRequest(
                "Value",
                "Contains",
                "i"
            );

        var tableReadRequest =
            new TableReadRequest(
                filterPropertyRequestRequest.WrapByReadOnlyList(),
                10,
                1,
                "id",
                OrderingType.Ascending
            );

        var adminIdentity =
            new ArcIdentity(
                1,
                ActorTypes.Admin
            );

        var result =
            await
                facade
                    .Execute(
                        tableReadRequest,
                        adminIdentity
                    );

        var responseList =
            result.ValidateSuccess<List<ComplexPropertyReadResponse>>();

        responseList
            .Should()
            .NotBeEmpty();

        responseList
            .Should()
            .HaveCount(
                2
            );
    }
}