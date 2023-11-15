using System;
using System.Linq.Expressions;

using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Infrastructure.Services.Implementations;

public sealed class GenericPropertyLambdaSelector :
    IGenericPropertyLambdaSelector
{
    public dynamic GetLambda<TEntity>(
        string propertyName
    )
    {
        var entityType =
            typeof(TEntity);

        var propertyInfo =
            entityType
                .GetProperty(
                    propertyName
                );

        var propertyType =
            propertyInfo?
                .PropertyType;

        dynamic propertyLambda =
            default!;

        var isBool =
            propertyType
            == typeof(bool);

        if (isBool)
        {
            propertyLambda =
                GetLambda<TEntity, bool>(
                    entityType,
                    propertyName
                );
        }

        var isInteger =
            propertyType
            == typeof(int);

        if (isInteger)
        {
            propertyLambda =
                GetLambda<TEntity, int>(
                    entityType,
                    propertyName
                );
        }

        var isString =
            propertyType
            == typeof(string);

        if (isString)
        {
            propertyLambda =
                GetLambda<TEntity, string>(
                    entityType,
                    propertyName
                );
        }

        return
            propertyLambda;
    }

    private static Expression<Func<TEntity, TProperty>> GetLambda
        <
            TEntity,
            TProperty
        >(
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