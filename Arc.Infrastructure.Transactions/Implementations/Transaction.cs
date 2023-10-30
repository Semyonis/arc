using Arc.Database.Context;
using Arc.Infrastructure.Transactions.Interfaces;

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
    }

    public void Rollback() =>
        _transaction.Rollback();

#region Constructor

    private readonly ArcDatabaseContext
        _context;

    private readonly IDbContextTransaction
        _transaction;

    public Transaction(
        ArcDatabaseContext
            context,
        IDbContextTransaction
            transaction
    )
    {
        _context =
            context;

        _transaction =
            transaction;
    }

#endregion
}