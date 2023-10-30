using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Arc.Infrastructure.Repositories.Interfaces.Base;

namespace Arc.Infrastructure.Repositories.Interfaces;

public interface ICreateRepository :
    IRepository
{
    Task<int> CreateAsync<TEntity>(
        TEntity item,
        CancellationToken cancellationToken = default
    )
        where TEntity : class;

    Task<int> CreateAsync<TEntity>(
        IEnumerable<TEntity> items,
        CancellationToken cancellationToken = default
    )
        where TEntity : class;
}