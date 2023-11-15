using Arc.Database.Context;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Infrastructure.Transactions.Interfaces;

namespace Arc.Infrastructure.Transactions.Implementations;

public sealed class TransactionManager(
        ArcDatabaseContext context,
        IDictionariesManager
            dictionariesManager
    )
    :
        ITransactionManager
{
    public async Task<ITransaction> BeginTransaction()
    {
        var transactionDb =
            await
                context
                    .Database
                    .BeginTransactionAsync();

        return
            new Transaction(
                context,
                transactionDb,
                dictionariesManager
            );
    }
}