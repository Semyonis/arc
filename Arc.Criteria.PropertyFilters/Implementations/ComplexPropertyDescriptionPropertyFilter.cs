using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class ComplexPropertyDescriptionPropertyFilter :
    IComplexPropertyDescriptionPropertyFilter
{
    private readonly IItemCompareFunctions
        _itemCompareFunctions;

    public ComplexPropertyDescriptionPropertyFilter(
        IItemCompareFunctions
            itemCompareFunctions
    ) =>
        _itemCompareFunctions =
            itemCompareFunctions;

    public PropertyFilterParameter<ComplexPropertyDescription, int> GetComplexPropertyIdEqualFilter(
        int pattern
    )
    {
        var propertyPredicate =
            ComplexPropertyDescriptionExpressions.GetComplexPropertyId();

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