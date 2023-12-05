using Arc.Converters.Views.Admins.Interfaces;
using Arc.Converters.Views.Common.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Models.Views.Admins.Tables.Models.Groups;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Groups;

public sealed class GroupsTableFacade(
    IGroupsReadRepository
        readRepository,
    IPageResponsesDomainFacade
        internalResponsesFacade,
    IGroupToGroupReadResponseConverter
        readConverter,
    IOrderingService
        orderingService,
    IGenericPropertyLambdaSelector
        parameterConverter,
    IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter
        filterPropertyRequestRequestToFilterPropertyRequestModelConverter,
    IGenericFilterPropertyFactory
        genericFilterPropertyFactory,
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor
) : BaseTableFacade
    <
        Group,
        GroupReadResponse
    >(
        readRepository,
        internalResponsesFacade,
        readConverter,
        orderingService,
        parameterConverter,
        filterPropertyRequestRequestToFilterPropertyRequestModelConverter,
        genericFilterPropertyFactory,
        badDataExceptionDescriptor
    ),
    IGroupsTableFacade
{
    protected override
        Func<IQueryable<Group>, IIncludableQueryable<Group, object>>
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription();
}