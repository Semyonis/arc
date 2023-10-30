using Arc.Converters.Views.Admins.Interfaces;
using Arc.Converters.Views.Common.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Groups;

public sealed class GroupsTableFacade :
    BaseTableFacade
    <
        Group,
        GroupReadResponse
    >,
    IGroupsTableFacade
{
    public GroupsTableFacade(
        IGroupsReadRepository
            readRepository,
        IPageResponsesDomainFacade
            internalResponsesFacade,
        IGroupToGroupReadResponseConverter
            readConverter,
        IOrderingService
            orderingService,
        IGroupFilterParameterFactoryService
            filterParameterConverter,
        IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter
            filterPropertyRequestRequestToFilterPropertyRequestModelConverter
    ) : base(
        readRepository,
        internalResponsesFacade,
        readConverter,
        orderingService,
        filterParameterConverter,
        filterPropertyRequestRequestToFilterPropertyRequestModelConverter
    ) { }

    protected override
        Func<IQueryable<Group>, IIncludableQueryable<Group, object>>
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription();
}