using Arc.Database.Context;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Infrastructure.Transactions.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Arc.Infrastructure.Transactions.Implementations;

public sealed class Transaction :
    ITransaction
{
    public void Dispose() =>
        _transaction.Dispose();

    public async Task Commit()
    {
        await
            _context.SaveChangesAsync();

        await
            _transaction.CommitAsync();

        var updatedEntities =
            GetUpdatedOrDeletedEntityTypes();

        foreach (var entityType in updatedEntities)
        {
            _dictionariesManager
                .Update(
                    entityType
                );
        }
    }

    private IEnumerable<Type> GetUpdatedOrDeletedEntityTypes() =>
        _context
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

    public void Rollback() =>
        _transaction.Rollback();

#region Constructor

    private readonly ArcDatabaseContext
        _context;

    private readonly IDbContextTransaction
        _transaction;

    private readonly IDictionariesManager
        _dictionariesManager;

    public Transaction(
        ArcDatabaseContext
            context,
        IDbContextTransaction
            transaction,
        IDictionariesManager
            dictionariesManager
    )
    {
        _context =
            context;

        _transaction =
            transaction;

        _dictionariesManager =
            dictionariesManager;
    }

#endregion
}