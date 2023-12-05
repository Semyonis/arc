using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Database.Entities.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IActorPropertyFilters
{
    FilterParameterBase<Actor> GetEmailEqualFilter(
        string pattern
    );
}