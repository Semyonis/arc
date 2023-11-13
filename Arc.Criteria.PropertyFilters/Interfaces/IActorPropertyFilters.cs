using Arc.Criteria.FilterParameters.Implementations;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Models.DataBase.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IActorPropertyFilters
{
    FilterParameterBase<Actor> GetEmailEqualFilter(
        string pattern
    );
}