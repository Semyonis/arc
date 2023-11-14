using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Interfaces;

public interface IGenericFilterPropertyFromExpressionFactoryService
{
    FilterParameterBase<TEntity> GetProperty<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> expression,
        FilterPropertyModel filter
    );
}