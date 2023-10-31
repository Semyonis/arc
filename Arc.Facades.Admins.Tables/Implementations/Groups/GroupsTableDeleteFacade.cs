using Arc.Criteria.PropertyFilters.Interfaces;
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
using Arc.Models.DataBase.Models;

using Microsoft.EntityFrameworkCore.Query;

using static Arc.Infrastructure.Common.Enums.OperationType;

namespace Arc.Facades.Admins.Tables.Implementations.Groups;

public sealed class GroupsTableDeleteFacade :
    BaseTableDeleteFacade
    <Group>,
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
                    _complexPropertyPropertyFilter
                        .GetGroupIdEqualFilter
                );

        var complexProperties =
            await
                _complexPropertiesReadRepository
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
                _badDataExceptionDescriptor
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
                    _groupDescriptionPropertyFilter
                        .GetGroupIdEqualFilter
                );

        var descriptions =
            await
                _groupDescriptionsReadRepository
                    .GetListByFiltersAsync(
                        filters.ToList(),
                        operationType: Or
                    );

        await
            _groupDescriptionsRepository
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

#region Constructor

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    private readonly IComplexPropertiesReadRepository
        _complexPropertiesReadRepository;

    private readonly IGroupDescriptionsReadRepository
        _groupDescriptionsReadRepository;

    private readonly IDeleteRepository
        _groupDescriptionsRepository;

    private readonly IComplexPropertyPropertyFilter
        _complexPropertyPropertyFilter;

    private readonly IGroupDescriptionPropertyFilter
        _groupDescriptionPropertyFilter;

    public GroupsTableDeleteFacade(
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
    ) : base(
        repository,
        internalFacade,
        transactionManager,
        readRepository
    )
    {
        _groupDescriptionsRepository =
            groupDescriptionsRepository;

        _groupDescriptionsReadRepository =
            groupDescriptionsReadRepository;

        _complexPropertiesReadRepository =
            complexPropertiesReadRepository;

        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;

        _complexPropertyPropertyFilter =
            complexPropertyPropertyFilter;

        _groupDescriptionPropertyFilter =
            groupDescriptionPropertyFilter;
    }

#endregion
}