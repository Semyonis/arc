using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

using Microsoft.EntityFrameworkCore;

namespace Arc.Infrastructure.Repositories.Implementations;

public sealed class DeleteRepository :
    Repository,
    IDeleteRepository
{
    public DeleteRepository(
        ArcDatabaseContext
            context,
        IDictionariesManager
            dictionariesManager
    ) : base(
        context,
        dictionariesManager
    ) { }

    public async Task<int> DeleteAsync<TEntity>(
        TEntity item,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        Action<DbSet<TEntity>, TEntity> action = (
            set,
            entity
        ) => set.Remove(
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

    public async Task<int> DeleteCollectionAsync<TEntity>(
        IEnumerable<TEntity> items,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        Action<DbSet<TEntity>, IEnumerable<TEntity>> action =
        (
            set,
            entity
        ) => set.RemoveRange(
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