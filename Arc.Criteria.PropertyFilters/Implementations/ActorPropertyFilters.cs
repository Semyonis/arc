using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;
using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ActorExpressions;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class ActorPropertyFilters :
    IActorPropertyFilters
{
    private readonly IGenericFilterPropertyFromExpressionFactoryService
        _genericFilterPropertyFromExpressionFactoryService;

    public ActorPropertyFilters(
        IGenericFilterPropertyFromExpressionFactoryService
            genericFilterPropertyFromExpressionFactoryService
    ) =>
        _genericFilterPropertyFromExpressionFactoryService =
            genericFilterPropertyFromExpressionFactoryService;

    public FilterParameterBase<Actor> GetEmailEqualFilter(
        string pattern
    )
    {
        var filterPropertyRequestModel =
            new FilterPropertyModel(
                Equal,
                pattern
            );

        return
            _genericFilterPropertyFromExpressionFactoryService
                .GetProperty(
                    GetEmail(),
                    filterPropertyRequestModel
                );
    }
}