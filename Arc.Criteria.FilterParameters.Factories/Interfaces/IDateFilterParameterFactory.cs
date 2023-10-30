using Arc.Criteria.FilterParameters.Implementations;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Interfaces;

public interface IDateFilterParameterFactory
{
    FilterParameterBase<TEntity> GetFilterParameter
    <
        TEntity
    >(
        FilterPropertyRequestModel filter,
        Expression
        <
            Func<TEntity, DateTime>
        > propertyPredicate
    );
}