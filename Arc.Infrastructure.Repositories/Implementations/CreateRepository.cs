using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

using Microsoft.EntityFrameworkCore;

namespace Arc.Infrastructure.Repositories.Implementations;

public sealed class CreateRepository(
    ArcDatabaseContext
        context,
    IDictionariesManager
        dictionariesManager
) : Repository(
        context,
        dictionariesManager
    ),
    ICreateRepository
{
    public async Task<int> CreateAsync<TEntity>(
        TEntity item,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        Action<DbSet<TEntity>, TEntity> action = (
            set,
            entity
        ) => set.Add(
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

    public async Task<int> CreateCollectionAsync<TEntity>(
        IEnumerable<TEntity> items,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        Action<DbSet<TEntity>, IEnumerable<TEntity>> action = (
            set,
            entity
        ) => set.AddRange(
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