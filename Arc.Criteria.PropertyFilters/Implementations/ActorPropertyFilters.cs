using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class ActorPropertyFilters :
    IActorPropertyFilters
{
    private readonly IGenericFilterPropertyFactoryService
        _genericFilterPropertyFactoryService;

    public ActorPropertyFilters(
        IGenericFilterPropertyFactoryService
            genericFilterPropertyFactoryService
    ) =>
        _genericFilterPropertyFactoryService =
            genericFilterPropertyFactoryService;

    public FilterParameterBase<Actor> GetEmailEqualFilter(
        string pattern
    )
    {
        const string Email =
            "Email";

        var filterPropertyRequestModel =
            new FilterPropertyRequestModel(
                Email,
                Equal,
                pattern
            );

        return
            _genericFilterPropertyFactoryService
                .GetProperty<Actor>(
                    filterPropertyRequestModel
                );
    }
}