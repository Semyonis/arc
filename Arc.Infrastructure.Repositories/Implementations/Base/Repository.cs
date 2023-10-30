using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Arc.Infrastructure.Repositories.Implementations.Base;

public abstract class Repository
{
    private readonly ArcDatabaseContext
        _context;

    protected Repository(
        ArcDatabaseContext context
    ) =>
        _context =
            context;

    protected async Task<int> InvokeActionAndSaveChangesAsync<TEntity>(
        TEntity item,
        Action<DbSet<TEntity>, TEntity> action,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        await
            InvokeActionAsync(
                item,
                action,
                cancellationToken
            );

        return
            await
                SaveChangesAsync(
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
        await
            InvokeActionAsync(
                items,
                action,
                cancellationToken
            );

        return
            await
                SaveChangesAsync(
                    cancellationToken
                );
    }

    private async Task InvokeActionAsync<TEntity>(
        TEntity entity,
        Action<DbSet<TEntity>, TEntity> action,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        var entitySet =
            GetSet<TEntity>();

        action(
            entitySet,
            entity
        );

        await
            SaveChangesAsync(
                cancellationToken
            );
    }

    private async Task InvokeActionAsync<TEntity>(
        IEnumerable<TEntity> entities,
        Action<DbSet<TEntity>, IEnumerable<TEntity>> action,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        var entitySet =
            GetSet<TEntity>();

        action(
            entitySet,
            entities
        );

        await
            SaveChangesAsync(
                cancellationToken
            );
    }

    private DbSet<TEntity> GetSet<TEntity>()
        where TEntity : class =>
        _context
            .Set<TEntity>();

    private Task<int> SaveChangesAsync(
        CancellationToken cancellationToken
    ) =>
        _context
            .SaveChangesAsync(
                cancellationToken
            );
}