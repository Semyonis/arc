using Arc.Converters.Views.Admins.Interfaces;
using Arc.Converters.Views.Common.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableFacade(
    IComplexPropertiesReadRepository
        readRepository,
    IPageResponsesDomainFacade
        internalResponsesFacade,
    IComplexPropertyToComplexPropertyReadResponseConverter
        readResponseConverter,
    IOrderingService
        orderingService,
    IGenericPropertyLambdaSelector
        parameterConverter,
    IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter
        filterPropertyRequestRequestToFilterPropertyRequestModelConverter,
    IGenericFilterPropertyFactory
        genericFilterPropertyFactory
) : BaseTableFacade
    <
        ComplexProperty,
        ComplexPropertyReadResponse
    >(
        readRepository,
        internalResponsesFacade,
        readResponseConverter,
        orderingService,
        parameterConverter,
        filterPropertyRequestRequestToFilterPropertyRequestModelConverter,
        genericFilterPropertyFactory
    ),
    IComplexPropertiesTableFacade
{
    protected override
        Func<IQueryable<ComplexProperty>, IIncludableQueryable<ComplexProperty, object>>
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription()
                .IncludeGroupDescription();
}