using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models;

namespace Arc.Infrastructure.Services.Interfaces;

public interface IOrderingService
{
    ResultContainer<OrderingParam<TEntity>?> GetOrderingExpression<TEntity, TValue>(
        TValue value
    )
        where TValue : IWithOrderBy, IWithOrderingType;
}