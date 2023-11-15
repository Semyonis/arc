using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.DataBase.Models;

using Microsoft.EntityFrameworkCore.Query;

using static Arc.Infrastructure.Common.Enums.OperationType;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableDeleteFacade(
    IDeleteRepository
        repository,
    IComplexPropertiesReadRepository
        readRepository,
    IResponsesDomainFacade
        internalFacade,
    IDeleteRepository
        complexPropertyDescriptionRepository,
    ITransactionManager
        transactionManager,
    IComplexPropertyDescriptionsReadRepository
        complexPropertyDescriptionReadRepository,
    IComplexPropertyDescriptionPropertyFilter
        complexPropertyDescriptionPropertyFilter
) : BaseTableDeleteFacade
    <ComplexProperty>(
        repository,
        internalFacade,
        transactionManager,
        readRepository
    ),
    IComplexPropertiesTableDeleteFacade
{
    protected override
        Func<IQueryable<ComplexProperty>, IIncludableQueryable<ComplexProperty, object>>
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription();

    protected override async Task PrepareOnDelete(
        IReadOnlyList<int> ids
    )
    {
        var filters =
            ids
                .Select(
                    complexPropertyDescriptionPropertyFilter
                        .GetComplexPropertyIdEqualFilter
                );

        var descriptions =
            await
                complexPropertyDescriptionReadRepository
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