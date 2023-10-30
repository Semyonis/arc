using Arc.Criteria.FilterParameters.Implementations;
using Arc.Models.DataBase.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IComplexPropertyDescriptionPropertyFilter
{
    PropertyFilterParameter<ComplexPropertyDescription, int> GetComplexPropertyIdEqualFilter(
        int pattern
    );
}