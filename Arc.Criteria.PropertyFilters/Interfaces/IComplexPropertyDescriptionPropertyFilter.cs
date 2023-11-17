using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Models.DataBase.Models;

namespace Arc.Criteria.PropertyFilters.Interfaces;

public interface IComplexPropertyDescriptionPropertyFilter
{
    FilterParameterBase<ComplexPropertyDescription> GetComplexPropertyIdEqualFilter(
        int pattern
    );
}