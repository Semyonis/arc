using System.Linq.Expressions;

using Arc.Infrastructure.Common.Enums;

namespace Arc.Infrastructure.Common.Models;

public sealed record OrderingParam<TEntity>(
    OrderingType OrderingType,
    Expression<Func<TEntity, object>> Expression
);