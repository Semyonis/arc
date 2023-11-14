using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Interfaces;

public interface IGenericFilterPropertyFromStringValueFactoryService
{
    FilterParameterBase<TEntity> GetProperty<TEntity>(
        FilterPropertyRequestModel filter
    );
}