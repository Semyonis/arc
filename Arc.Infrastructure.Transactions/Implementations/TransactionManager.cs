using Arc.Database.Context;
using Arc.Infrastructure.Transactions.Interfaces;

namespace Arc.Infrastructure.Transactions.Implementations;

public sealed class TransactionManager :
    ITransactionManager
{
    private readonly ArcDatabaseContext
        _context;

    public TransactionManager(
        ArcDatabaseContext context
    ) =>
        _context = context;

    public async Task<ITransaction> BeginTransaction()
    {
        var transactionDb =
            await
                _context
                    .Database
                    .BeginTransactionAsync();

        return new Transaction(
            _context,
            transactionDb
        );
    }
}