using System;
using System.Linq.Expressions;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models;
using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Infrastructure.Services.Implementations;

public sealed class OrderingService :
    IOrderingService
{
    public OrderingParam<TEntity>? GetOrderingExpression<TEntity, TValue>(
        TValue value
    )
        where TValue : IWithOrderBy, IWithOrderingType
    {
        var isEmpty =
            value
                .OrderBy
                .IsEmpty();

        if (isEmpty)
        {
            return default;
        }

        var type =
            typeof(TEntity);

        var fieldName =
            value.OrderBy;

        var upperChar =
            char
                .ToUpperInvariant(
                    fieldName[0]
                );

        var titleCaseFieldName =
            $"{upperChar}{fieldName[1..]}";

        var prop =
            type
                .GetProperty(
                    titleCaseFieldName
                );

        if (prop == default)
        {
            return default;
        }

        var param =
            Expression
                .Parameter(
                    typeof(TEntity)
                );

        var body =
            Expression
                .PropertyOrField(
                    Expression.TypeAs(
                        param,
                        typeof(TEntity)
                    ),
                    prop.Name
                );

        var conversion =
            Expression
                .Convert(
                    body,
                    typeof(object)
                );

        var getterExpression =
            Expression
                .Lambda<Func<TEntity, object>>(
                    conversion,
                    param
                );

        return new(
            value.OrderingType,
            getterExpression
        );
    }
}