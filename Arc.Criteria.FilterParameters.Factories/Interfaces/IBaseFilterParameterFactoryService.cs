using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Interfaces;

public interface IBaseFilterParameterFactoryService<TEntity>
{
    IReadOnlyList<FilterParameterBase<TEntity>> GetProperties(
        IReadOnlyList<FilterPropertyRequestModel> models
    );
}