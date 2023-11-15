using Arc.Converters.Views.Admins.Interfaces;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

using Microsoft.EntityFrameworkCore.Query;

using static Arc.Infrastructure.Common.Enums.OperationType;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableUpdateFacade(
        IUpdateRepository
            repository,
        IResponsesDomainFacade
            internalFacade,
        IComplexPropertyUpdateRequestToComplexPropertiesConverter
            updateConverter,
        IDeleteRepository
            complexPropertyDescriptionRepository,
        ITransactionManager
            transactionManager,
        IComplexPropertyDescriptionsReadRepository
            complexPropertyDescriptionsReadRepository,
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor,
        IComplexPropertyDescriptionPropertyFilter
            complexPropertyDescriptionPropertyFilter
    )
    :
        BaseTableUpdateFacade
        <
            ComplexProperty,
            ComplexPropertyUpdateRequest
        >(
            repository,
            internalFacade,
            updateConverter,
            transactionManager,
            badDataExceptionDescriptor
        ),
        IComplexPropertiesTableUpdateFacade
{
    public async Task<Response> Execute(
        ComplexPropertyTableUpdateRequest request,
        AdminIdentity identity
    ) =>
        await
            Execute(
                request.Items,
                identity
            );

    protected override
        Func<IQueryable<ComplexProperty>, IIncludableQueryable<ComplexProperty, object>>
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription();

    protected override async Task PrepareOnUpdate(
        IReadOnlyList<ComplexPropertyUpdateRequest> updateEntities
    )
    {
        var complexPropertyIds =
            updateEntities
                .Select(
                    entity =>
                        entity.Id
                )
                .ToList();

        var filters =
            complexPropertyIds
                .Select(
                    complexPropertyDescriptionPropertyFilter
                        .GetComplexPropertyIdEqualFilter
                );

        var descriptions =
            await
                complexPropertyDescriptionsReadRepository
                    .GetListByFiltersAsync(
                        filters.ToList(),
                        operationType: Or
                    );

        await
            complexPropertyDescriptionRepository
                .DeleteAsync(
                    descriptions
                );
    }
}