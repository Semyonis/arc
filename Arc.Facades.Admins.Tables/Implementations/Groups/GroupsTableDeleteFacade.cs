using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;

using Microsoft.EntityFrameworkCore.Query;

using static Arc.Infrastructure.Common.Enums.OperationType;

namespace Arc.Facades.Admins.Tables.Implementations.Groups;

public sealed class GroupsTableDeleteFacade(
    IDeleteRepository
        repository,
    IGroupsReadRepository
        readRepository,
    IResponsesDomainFacade
        internalFacade,
    IDeleteRepository
        groupDescriptionsRepository,
    ITransactionManager
        transactionManager,
    IGroupDescriptionsReadRepository
        groupDescriptionsReadRepository,
    IComplexPropertiesReadRepository
        complexPropertiesReadRepository,
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor,
    IComplexPropertyPropertyFilter
        complexPropertyPropertyFilter,
    IGroupDescriptionPropertyFilter
        groupDescriptionPropertyFilter
) : BaseTableDeleteFacade
    <Group>(
        repository,
        internalFacade,
        transactionManager,
        readRepository
    ),
    IGroupsTableDeleteFacade
{
    protected override async Task ValidateOnDelete(
        IReadOnlyList<int> ids,
        AdminIdentity adminIdentity
    )
    {
        var filters =
            ids
                .Select(
                    complexPropertyPropertyFilter
                        .GetGroupIdEqualFilter
                );

        var complexProperties =
            await
                complexPropertiesReadRepository
                    .GetListByFiltersAsync(
                        filters.ToList(),
                        operationType: Or,
                        include:
                        ComplexPropertiesIncludeExtensions.IncludeGroup
                    );

        if (complexProperties.IsNotEmpty())
        {
            var testId =
                complexProperties
                    .First()
                    .Group
                    .Id;

            throw
                badDataExceptionDescriptor
                    .CreateException(
                        testId
                    );
        }
    }

    protected override async Task PrepareOnDelete(
        IReadOnlyList<int> ids
    )
    {
        var filters =
            ids
                .Select(
                    groupDescriptionPropertyFilter
                        .GetGroupIdEqualFilter
                );

        var descriptions =
            await
                groupDescriptionsReadRepository
                    .GetListByFiltersAsync(
                        filters.ToList(),
                        operationType: Or
                    );

        await
            groupDescriptionsRepository
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