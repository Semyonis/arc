using Arc.Criteria.FilterParameters.Implementations;
using Arc.Models.DataBase.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IComplexPropertyPropertyFilter
{
    PropertyFilterParameter<ComplexProperty, int> GetGroupIdEqualFilter(
        int pattern
    );
}