using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class UserPropertyFilters(
        IGenericFilterPropertyFromExpressionFactoryService
            genericFilterPropertyFromExpressionFactoryService
    )
    :
        IUserPropertyFilters
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
            genericFilterPropertyFromExpressionFactoryService
                .GetProperty(
                    UserExpressions.GetEmail(),
                    filterPropertyRequestModel
                );
    }
}