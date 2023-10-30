using Arc.Criteria.FilterParameters.Implementations;
using Arc.Models.DataBase.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IUserPropertyFilters
{
    PropertyFilterParameter<User, string> GetEmailEqualFilter(
        string pattern
    );
}