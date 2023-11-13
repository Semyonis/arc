using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace Arc.Tests.Integrations.Extensions;

internal static class ContextExtensions
{
    public static DbContext AddEntity<TEntity>(
        this DbContext context,
        TEntity newEntity
    )
        where TEntity : class
    {
        var entities =
            context
                .Set<TEntity>();

        entities
            .Add(
                newEntity
            );

        context
            .SaveChanges();

        context
            .DetachAll();

        return
            context;
    }
    
    public static DbContext AddEntities<TEntity>(
        this DbContext context,
        IEnumerable<TEntity> newEntities
    )
        where TEntity : class
    {
        var entities =
            context
                .Set<TEntity>();

        entities
            .AddRange(
                newEntities
            );

        context
            .SaveChanges();

        context
            .DetachAll();

        return
            context;
    }

    private static void DetachAll(
        this DbContext context
    )
    {
        var contextChangeTracker =
            context.ChangeTracker;

        var entries =
            contextChangeTracker
                .Entries()
                .ToList();

        foreach (var entry in entries)
        {
            var entity =
                context
                    .Entry(
                        entry.Entity
                    );

            entity.State =
                EntityState.Detached;
        }
    }
}