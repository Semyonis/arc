using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

using Microsoft.EntityFrameworkCore;

namespace Arc.Infrastructure.Repositories.Implementations.Base;

public abstract class Repository
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
            _context
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
            _context
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
            _context
                .SaveChangesAsync(
                    cancellationToken
                );

        var databaseCurrentTransaction =
            _context
                .Database
                .CurrentTransaction;

        if (databaseCurrentTransaction == default)
        {
            _dictionariesManager
                .Update(
                    typeof(TEntity)
                );
        }

        return updatedEntitiesCount;
    }

#region Constructor

    private readonly ArcDatabaseContext
        _context;

    private readonly IDictionariesManager
        _dictionariesManager;

    protected Repository(
        ArcDatabaseContext
            context,
        IDictionariesManager
            dictionariesManager
    )
    {
        _context =
            context;

        _dictionariesManager =
            dictionariesManager;
    }

#endregion
}