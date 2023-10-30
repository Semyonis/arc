using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Arc.Infrastructure.Repositories.Interfaces.Base;

namespace Arc.Infrastructure.Repositories.Interfaces;

public interface IUpdateRepository :
    IRepository
{
    Task<int> UpdateAsync<TEntity>(
        TEntity item,
        CancellationToken cancellationToken = default
    )
        where TEntity : class;

    Task<int> UpdateAsync<TEntity>(
        IEnumerable<TEntity> items,
        CancellationToken cancellationToken = default
    )
        where TEntity : class;
}