using Arc.Criteria.FilterParameters.Implementations;
using Arc.Models.DataBase.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IActorPropertyFilters
{
    PropertyFilterParameter<Actor, string> GetEmailEqualFilter(
        string pattern
    );
}