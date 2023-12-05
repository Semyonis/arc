using Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Models.BusinessLogic.Models.FilterProperties;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;
using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.ActorExpressions;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class ActorPropertyFilters(
    IGenericFilterPropertyFactory
        genericFilterPropertyFactory
) : IActorPropertyFilters
{
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
            genericFilterPropertyFactory
                .GetProperty(
                    GetEmail(),
                    filterPropertyRequestModel
                );
    }
}