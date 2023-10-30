using Arc.Criteria.CompareFunctions.Interfaces;
using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Common.Constants.Filters.FilterOperationConstants;

namespace Arc.Criteria.PropertyFilters.Implementations;

public sealed class UserPropertyFilters :
    IUserPropertyFilters
{
    private readonly IStringCompareFunctions
        _stringCompareFunctions;

    public UserPropertyFilters(
        IStringCompareFunctions
            stringCompareFunctions
    ) =>
        _stringCompareFunctions =
            stringCompareFunctions;

    public PropertyFilterParameter<User, string> GetEmailEqualFilter(
        string pattern
    )
    {
        var propertyPredicate =
            UserExpressions.GetEmail();

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