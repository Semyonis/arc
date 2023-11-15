using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;
using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.AdminExpressions;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class AdminPropertyFilters(
        IGenericFilterPropertyFromExpressionFactoryService
            genericFilterPropertyFromExpressionFactoryService
    )
    :
        IAdminPropertyFilters
{
    public FilterParameterBase<Admin> GetEmailEqualFilter(
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
                GetEmail(),
                filterPropertyRequestModel
            );
    }
}