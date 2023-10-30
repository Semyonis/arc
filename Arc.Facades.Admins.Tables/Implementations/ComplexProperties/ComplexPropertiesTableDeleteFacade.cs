using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.DataBase.Models;

using Microsoft.EntityFrameworkCore.Query;

using static Arc.Infrastructure.Common.Enums.OperationType;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableDeleteFacade :
    BaseTableDeleteFacade
    <ComplexProperty>,
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
                    _complexPropertyDescriptionPropertyFilter
                        .GetComplexPropertyIdEqualFilter
                );

        var descriptions =
            await
                _complexPropertyDescriptionReadRepository
                    .GetListByFiltersAsync(
                        filters.ToList(),
                        operationType: Or
                    );

        await
            _complexPropertyDescriptionRepository
                .DeleteAsync(
                    descriptions
                );
    }

#region Constructor

    private readonly IComplexPropertyDescriptionsReadRepository
        _complexPropertyDescriptionReadRepository;

    private readonly IDeleteRepository
        _complexPropertyDescriptionRepository;

    private readonly IComplexPropertyDescriptionPropertyFilter
        _complexPropertyDescriptionPropertyFilter;

    public ComplexPropertiesTableDeleteFacade(
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
        IDictionariesManager
            dictionariesManager,
        IComplexPropertyDescriptionsReadRepository
            complexPropertyDescriptionReadRepository,
        IComplexPropertyDescriptionPropertyFilter
            complexPropertyDescriptionPropertyFilter
    ) : base(
        repository,
        internalFacade,
        transactionManager,
        dictionariesManager,
        readRepository
    )
    {
        _complexPropertyDescriptionRepository =
            complexPropertyDescriptionRepository;

        _complexPropertyDescriptionReadRepository =
            complexPropertyDescriptionReadRepository;

        _complexPropertyDescriptionPropertyFilter =
            complexPropertyDescriptionPropertyFilter;
    }

#endregion
}