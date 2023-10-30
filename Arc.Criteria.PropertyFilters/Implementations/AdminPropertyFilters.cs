using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class AdminPropertyFilters :
    IAdminPropertyFilters
{
    private readonly IStringCompareFunctions
        _stringCompareFunctions;

    public AdminPropertyFilters(
        IStringCompareFunctions
            stringCompareFunctions
    ) =>
        _stringCompareFunctions =
            stringCompareFunctions;

    public PropertyFilterParameter<Admin, string> GetEmailEqualFilter(
        string pattern
    )
    {
        var propertyPredicate =
            AdminExpressions.GetEmail();

        var compareFunction =
            _stringCompareFunctions
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