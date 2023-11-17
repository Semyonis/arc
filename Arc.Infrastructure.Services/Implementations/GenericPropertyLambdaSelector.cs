using System;
using System.Linq.Expressions;

using Arc.Infrastructure.Common.Models;
using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Infrastructure.Services.Implementations;

public sealed class GenericPropertyLambdaSelector :
    IGenericPropertyLambdaSelector
{
    public ResultContainer<dynamic> GetLambda<TEntity>(
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

        Expression? lambda =
            propertyType switch
            {
                not null when propertyType == typeof(bool) =>
                    GetLambda<TEntity, bool>(
                        entityType,
                        propertyName
                    ),
                not null when propertyType == typeof(int) =>
                    GetLambda<TEntity, int>(
                        entityType,
                        propertyName
                    ),
                not null when propertyType == typeof(string) =>
                    GetLambda<TEntity, string>(
                        entityType,
                        propertyName
                    ),
                not null when propertyType == typeof(DateTime) =>
                    GetLambda<TEntity, DateTime>(
                        entityType,
                        propertyName
                    ),
                _ => default,
            };

        var isNotDefault =
            lambda != default;

        return
            isNotDefault
            ? ResultContainer<dynamic>.Successful(lambda!)
            : ResultContainer<dynamic>.Failed();
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