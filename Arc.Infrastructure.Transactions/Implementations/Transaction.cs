using Arc.Database.Context;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Infrastructure.Transactions.Interfaces;

using Microsoft.EntityFrameworkCore.Storage;

namespace Arc.Infrastructure.Transactions.Implementations;

public sealed class Transaction :
    ITransaction
{
    public void Dispose() =>
        _transaction.Dispose();

    public async Task Commit(
        params Type[] updatedEntityTypes
    )
    {
        await
            _context.SaveChangesAsync();

        await
            _transaction.CommitAsync();

        foreach (var entityType in updatedEntityTypes)
        {
            _dictionariesManager
                .Update(
                    entityType
                );
        }
    }

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