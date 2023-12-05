using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Database.Entities.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IUserPropertyFilters
{
    FilterParameterBase<User> GetEmailEqualFilter(
        string pattern
    );
}