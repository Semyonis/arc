using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Database.Entities.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IComplexPropertyPropertyFilter
{
    FilterParameterBase<ComplexProperty> GetGroupIdEqualFilter(
        int pattern
    );
}