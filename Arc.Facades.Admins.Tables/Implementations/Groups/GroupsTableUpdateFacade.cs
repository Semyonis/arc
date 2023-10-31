using Arc.Converters.Views.Admins.Interfaces;
using Arc.Criteria.PropertyFilters.Interfaces;
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
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

using Microsoft.EntityFrameworkCore.Query;

using static Arc.Infrastructure.Common.Enums.OperationType;

namespace Arc.Facades.Admins.Tables.Implementations.Groups;

public sealed class GroupsTableUpdateFacade :
    BaseTableUpdateFacade
    <
        Group,
        GroupUpdateResponse
    >,
    IGroupsTableUpdateFacade
{
    private readonly IGroupDescriptionPropertyFilter
        _groupDescriptionPropertyFilter;

    private readonly IGroupDescriptionsReadRepository
        _testDescriptionsReadRepository;

    private readonly IDeleteRepository
        _testDescriptionsRepository;

    public GroupsTableUpdateFacade(
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
    ) : base(
        repository,
        internalFacade,
        updateConverter,
        transactionManager,
        badDataExceptionDescriptor
    )
    {
        _testDescriptionsRepository =
            testDescriptionsRepository;

        _testDescriptionsReadRepository =
            testDescriptionsReadRepository;

        _groupDescriptionPropertyFilter =
            groupDescriptionPropertyFilter;
    }

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
                    _groupDescriptionPropertyFilter
                        .GetGroupIdEqualFilter
                );

        var descriptions =
            await
                _testDescriptionsReadRepository
                    .GetListByFiltersAsync(
                        filters.ToList(),
                        operationType: Or
                    );

        await
            _testDescriptionsRepository
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