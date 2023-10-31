using Arc.Database.Context;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Infrastructure.Transactions.Interfaces;

namespace Arc.Infrastructure.Transactions.Implementations;

public sealed class TransactionManager :
    ITransactionManager
{
    private readonly ArcDatabaseContext
        _context;

    private readonly IDictionariesManager
        _dictionariesManager;

    public TransactionManager(
        ArcDatabaseContext context,
        IDictionariesManager
            dictionariesManager
    )
    {
        _context =
            context;

        _dictionariesManager =
            dictionariesManager;
    }

    public async Task<ITransaction> BeginTransaction()
    {
        var transactionDb =
            await
                _context
                    .Database
                    .BeginTransactionAsync();

        return
            new Transaction(
                _context,
                transactionDb,
                _dictionariesManager
            );
    }
}