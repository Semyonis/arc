using Arc.Database.Context;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Infrastructure.Transactions.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Arc.Infrastructure.Transactions.Implementations;

public sealed class Transaction(
    ArcDatabaseContext
        context,
    IDbContextTransaction
        transaction,
    IDictionariesManager
        dictionariesManager
) : ITransaction
{
    public void Dispose() =>
        transaction.Dispose();

    public async Task Commit()
    {
        await
            context.SaveChangesAsync();

        await
            transaction.CommitAsync();

        var updatedEntities =
            GetUpdatedOrDeletedEntityTypes();

        foreach (var entityType in updatedEntities)
        {
            dictionariesManager
                .Update(
                    entityType
                );
        }
    }

    public void Rollback() =>
        transaction.Rollback();

    private IEnumerable<Type> GetUpdatedOrDeletedEntityTypes() =>
        context
            .ChangeTracker
            .Entries()
            .Where(
                IsModifiedOrDeleted
            )
            .Select(
                GetType
            );

    private static Type GetType(
        EntityEntry entity
    ) =>
        entity
            .Entity
            .GetType();

    private static bool IsModifiedOrDeleted(
        EntityEntry entity
    ) =>
        entity.State
            is EntityState.Modified
            or EntityState.Deleted;
}