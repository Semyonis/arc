using Arc.Converters.Views.Admins.Interfaces;
using Arc.Converters.Views.Common.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Facades.Admins.Tables.Implementations.SimpleProperties;

public sealed class SimplePropertiesTableFacade(
    ISimplePropertiesReadRepository
        readRepository,
    IPageResponsesDomainFacade
        internalResponsesFacade,
    ISimplePropertyToSimplePropertyReadResponseConverter
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
        SimpleProperty,
        SimplePropertyReadResponse
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
    ISimplePropertiesTableFacade;