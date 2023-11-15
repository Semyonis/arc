using Arc.Converters.Views.Admins.Interfaces;
using Arc.Converters.Views.Common.Interfaces;
using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Services.Interfaces;
using Arc.Models.DataBase.Models;
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
        IGenericFilterPropertyFromStringValueFactoryService
            filterParameterConverter,
        IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter
            filterPropertyRequestRequestToFilterPropertyRequestModelConverter
    )
    :
        BaseTableFacade
        <
            SimpleProperty,
            SimplePropertyReadResponse
        >(
            readRepository,
            internalResponsesFacade,
            readConverter,
            orderingService,
            filterParameterConverter,
            filterPropertyRequestRequestToFilterPropertyRequestModelConverter
        ),
        ISimplePropertiesTableFacade;