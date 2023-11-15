using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class GroupDescriptionPropertyFilter(
        IItemCompareFunctions
            itemCompareFunctions
    )
    :
        IGroupDescriptionPropertyFilter
{
    public PropertyFilterParameter<GroupDescription, int> GetGroupIdEqualFilter(
        int pattern
    )
    {
        var propertyPredicate =
            GroupDescriptionExpressions.GetGroupId();

        var compareFunction =
            itemCompareFunctions
                .GetFunction(
                    Equal
                );

        return new(
            propertyPredicate,
            compareFunction,
            pattern
        );
    }
}