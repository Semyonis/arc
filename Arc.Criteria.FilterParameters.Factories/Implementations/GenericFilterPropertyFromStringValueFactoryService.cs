using Arc.Criteria.FilterParameters.Factories.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Models.BusinessLogic.Models.FilterProperties;

namespace Arc.Criteria.FilterParameters.Factories.Implementations;
/// <summary>
/// For api requests 
/// </summary>
// todo : should be replaced by LambdaBuilderService instead ?
public sealed class GenericFilterPropertyFromStringValueFactoryService :
    IGenericFilterPropertyFromStringValueFactoryService
{
#region Constructor

    private readonly IGenericFilterPropertyFromExpressionFactoryService
        _genericFilterPropertyFromExpressionFactoryService;

    public GenericFilterPropertyFromStringValueFactoryService(
        IGenericFilterPropertyFromExpressionFactoryService
            genericFilterPropertyFromExpressionFactoryService
    ) =>
        _genericFilterPropertyFromExpressionFactoryService =
            genericFilterPropertyFromExpressionFactoryService;

#endregion
    public FilterParameterBase<TEntity> GetProperty<TEntity>(
        FilterPropertyRequestModel filter
    )
    {
        var entityType =
            typeof(TEntity);

        (
            var property,
            var operation,
            var value
        ) = filter;

        var propertyType =
            entityType
                .GetProperty(
                    property
                )
                ?.PropertyType;

        dynamic propertyLambda = default!;

        // todo : should reworked in some way. this check duplicates same in GenericFilterPropertyFromExpressionFactoryService
        var isBool =
            propertyType
            == typeof(bool);

        if (isBool)
        {
            propertyLambda =
                GetPropertyLambda<TEntity, bool>(
                    entityType,
                    property
                );
        }

        var isInteger =
            propertyType
            == typeof(int);

        if (isInteger)
        {
            propertyLambda =
                GetPropertyLambda<TEntity, int>(
                    entityType,
                    property
                );
        }

        var isString =
            propertyType
            == typeof(string);

        if (isString) {
            propertyLambda =
                GetPropertyLambda<TEntity, string>(
                    entityType,
                    property
                );
        }

        var filterPropertyModel =
            new FilterPropertyModel(
                operation,
                value
            );

        return
            _genericFilterPropertyFromExpressionFactoryService
                .GetProperty(
                    propertyLambda,
                    filterPropertyModel
                );
    }

    private static Expression<Func<TEntity, TProperty>> GetPropertyLambda<TEntity, TProperty>(
        Type entityType,
        string property
    )
    {
        var item =
            Expression
                .Parameter(
                    entityType,
                    "__entity"
                );

        var prop =
            Expression
                .Property(
                    item,
                    property
                );

        return
            Expression
                .Lambda<Func<TEntity, TProperty>>(
                    prop,
                    item
                );
    }
}