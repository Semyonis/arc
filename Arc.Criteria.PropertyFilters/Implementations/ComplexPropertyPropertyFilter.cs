using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class ComplexPropertyPropertyFilter :
    IComplexPropertyPropertyFilter
{
    private readonly IItemCompareFunctions
        _itemCompareFunctions;

    public ComplexPropertyPropertyFilter(
        IItemCompareFunctions
            itemCompareFunctions
    ) =>
        _itemCompareFunctions =
            itemCompareFunctions;

    public PropertyFilterParameter<ComplexProperty, int> GetGroupIdEqualFilter(
        int pattern
    )
    {
        var propertyPredicate =
            ComplexPropertyExpressions.GetGroupId();

        var compareFunction =
            _itemCompareFunctions
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