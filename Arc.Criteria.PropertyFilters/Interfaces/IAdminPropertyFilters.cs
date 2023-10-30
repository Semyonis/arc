using Arc.Criteria.FilterParameters.Implementations;
using Arc.Models.DataBase.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IAdminPropertyFilters
{
    PropertyFilterParameter<Admin, string> GetEmailEqualFilter(
        string pattern
    );
}