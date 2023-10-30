using Arc.Criteria.FilterParameters.Implementations;
using Arc.Models.DataBase.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IGroupDescriptionPropertyFilter
{
    PropertyFilterParameter<GroupDescription, int> GetGroupIdEqualFilter(
        int pattern
    );
}