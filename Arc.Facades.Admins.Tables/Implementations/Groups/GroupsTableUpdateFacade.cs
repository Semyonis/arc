using Arc.Converters.Views.Admins.Interfaces;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Tables.Models.Groups;

using Microsoft.EntityFrameworkCore.Query;

using static Arc.Infrastructure.Common.Enums.OperationType;

namespace Arc.Facades.Admins.Tables.Implementations.Groups;

public sealed class GroupsTableUpdateFacade(
    IUpdateRepository
        repository,
    IResponsesDomainFacade
        internalFacade,
    IGroupUpdateResponseToGroupsConverter
        updateConverter,
    IDeleteRepository
        testDescriptionsRepository,
    ITransactionManager
        transactionManager,
    IGroupDescriptionsReadRepository
        testDescriptionsReadRepository,
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor,
    IGroupDescriptionPropertyFilter
        groupDescriptionPropertyFilter
) : BaseTableUpdateFacade
    <
        Group,
        GroupUpdateResponse
    >(
        repository,
        internalFacade,
        updateConverter,
        transactionManager,
        badDataExceptionDescriptor
    ),
    IGroupsTableUpdateFacade
{
    public async Task<Response> Execute(
        GroupTableUpdateRequest tableRequest,
        AdminIdentity identity
    ) =>
        await
            Execute(
                tableRequest.Items,
                identity
            );

    protected override async Task PrepareOnUpdate(
        IReadOnlyList<GroupUpdateResponse> updateEntities
    )
    {
        var testIds =
            updateEntities
                .Select(
                    entity =>
                        entity.Id
                )
                .ToList();

        var filters =
            testIds
                .Select(
                    groupDescriptionPropertyFilter
                        .GetGroupIdEqualFilter
                );

        var descriptions =
            await
                testDescriptionsReadRepository
                    .GetListByFiltersAsync(
                        filters.ToList(),
                        operationType: Or
                    );

        await
            testDescriptionsRepository
                .DeleteAsync(
                    descriptions
                );
    }

    protected override
        Func<IQueryable<Group>, IIncludableQueryable<Group, object>>
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription();
}