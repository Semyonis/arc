using Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class ComplexPropertyPropertyFilter(
    IGenericFilterPropertyFactory
        genericFilterPropertyFactory
) : IComplexPropertyPropertyFilter
{
    public FilterParameterBase<ComplexProperty> GetGroupIdEqualFilter(
        int pattern
    )
    {
        var filterPropertyRequestModel =
            new FilterPropertyModel(
                Equal,
                pattern.ToString()
            );

        return
            genericFilterPropertyFactory
                .GetProperty(
                    ComplexPropertyExpressions.GetGroupId(),
                    filterPropertyRequestModel
                );
    }
}