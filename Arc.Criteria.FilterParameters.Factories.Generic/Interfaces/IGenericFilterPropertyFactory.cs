using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Generic.Interfaces;

public interface IGenericFilterPropertyFactory
{
    FilterParameterBase<TEntity> GetProperty<TEntity, TProperty>(
        Expression<Func<TEntity, TProperty>> expression,
        FilterPropertyModel filter
    );
}