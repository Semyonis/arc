using Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;
using Arc.Models.BusinessLogic.Models.FilterProperties;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class UserPropertyFilters(
    IGenericFilterPropertyFactory
        genericFilterPropertyFactory
) : IUserPropertyFilters
{
    public FilterParameterBase<User> GetEmailEqualFilter(
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
                    UserExpressions.GetEmail(),
                    filterPropertyRequestModel
                );
    }
}