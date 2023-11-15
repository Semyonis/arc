using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

using Microsoft.EntityFrameworkCore;

namespace Arc.Infrastructure.Repositories.Implementations;

public sealed class UpdateRepository(
        ArcDatabaseContext
            context,
        IDictionariesManager
            dictionariesManager
    )
    :
        Repository(
            context,
            dictionariesManager
        ),
        IUpdateRepository
{
    public async Task<int> UpdateAsync<TEntity>(
        TEntity item,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        Action<DbSet<TEntity>, TEntity> action = (
            set,
            entity
        ) => set.Update(
            entity
        );

        return
            await
                InvokeActionAndSaveChangesAsync(
                    item,
                    action,
                    cancellationToken
                );
    }

    public async Task<int> UpdateCollectionAsync<TEntity>(
        IEnumerable<TEntity> items,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        Action<DbSet<TEntity>, IEnumerable<TEntity>> action = (
            set,
            entity
        ) => set.UpdateRange(
            entity
        );

        return
            await
                InvokeActionAndSaveChangesAsync(
                    items,
                    action,
                    cancellationToken
                );
    }
}