using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

using Microsoft.EntityFrameworkCore;

namespace Arc.Infrastructure.Repositories.Implementations.Base;

public abstract class Repository(
    ArcDatabaseContext
        context,
    IDictionariesManager
        dictionariesManager
)
{
    protected async Task<int> InvokeActionAndSaveChangesAsync<TEntity>(
        TEntity item,
        Action<DbSet<TEntity>, TEntity> action,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        InvokeActionAsync(
            item,
            action
        );

        return
            await
                SaveChangesAsync<TEntity>(
                    cancellationToken
                );
    }

    protected async Task<int> InvokeActionAndSaveChangesAsync<TEntity>(
        IEnumerable<TEntity> items,
        Action<DbSet<TEntity>, IEnumerable<TEntity>> action,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        InvokeActionAsync(
            items,
            action
        );

        return
            await
                SaveChangesAsync<TEntity>(
                    cancellationToken
                );
    }

    private void InvokeActionAsync<TEntity>(
        TEntity entity,
        Action<DbSet<TEntity>, TEntity> action
    )
        where TEntity : class
    {
        var entitySet =
            context
                .Set<TEntity>();

        action(
            entitySet,
            entity
        );
    }

    private void InvokeActionAsync<TEntity>(
        IEnumerable<TEntity> entities,
        Action<DbSet<TEntity>, IEnumerable<TEntity>> action
    )
        where TEntity : class
    {
        var entitySet =
            context
                .Set<TEntity>();

        action(
            entitySet,
            entities
        );
    }

    private Task<int> SaveChangesAsync<TEntity>(
        CancellationToken cancellationToken
    )
    {
        var updatedEntitiesCount =
            context
                .SaveChangesAsync(
                    cancellationToken
                );

        var databaseCurrentTransaction =
            context
                .Database
                .CurrentTransaction;

        if (databaseCurrentTransaction == default)
        {
            dictionariesManager
                .Update(
                    typeof(TEntity)
                );
        }

        return updatedEntitiesCount;
    }
}