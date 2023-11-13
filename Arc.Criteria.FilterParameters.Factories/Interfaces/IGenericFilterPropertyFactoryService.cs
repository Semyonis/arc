using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Interfaces;

public interface IGenericFilterPropertyFactoryService
{
    IReadOnlyList<FilterParameterBase<TEntity>> GetProperties<TEntity>(
        IReadOnlyList<FilterPropertyRequestModel> models
    );

    FilterParameterBase<TEntity> GetProperty<TEntity>(
        FilterPropertyRequestModel filter
    );
}