using Arc.Criteria.FilterParameters.Implementations;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Interfaces;

public interface IItemListFilterParameterFactory
{
    FilterParameterBase<TEntity> GetFilterParameter
    <
        TEntity,
        TProperty
    >(
        FilterPropertyRequestModel filter,
        Expression
        <
            Func<TEntity, ICollection<TProperty>>
        > collectionPropertyPredicate,
        Expression
        <
            Func<TProperty, int>
        > propertyValuePredicate
    );
}