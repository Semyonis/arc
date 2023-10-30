using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Arc.Infrastructure.Repositories.Interfaces.Base;

namespace Arc.Infrastructure.Repositories.Interfaces;

public interface IDeleteRepository :
    IRepository
{
    Task<int> DeleteAsync<TEntity>(
        TEntity item,
        CancellationToken cancellationToken = default
    )
        where TEntity : class;

    Task<int> DeleteAsync<TEntity>(
        IEnumerable<TEntity> items,
        CancellationToken cancellationToken = default
    )
        where TEntity : class;
}