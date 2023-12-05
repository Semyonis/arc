using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Database.Entities.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IAdminPropertyFilters
{
    FilterParameterBase<Admin> GetEmailEqualFilter(
        string pattern
    );
}