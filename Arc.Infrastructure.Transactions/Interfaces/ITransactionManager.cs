namespace Arc.Infrastructure.Transactions.Interfaces;

public interface ITransactionManager
{
    Task<ITransaction> BeginTransaction();
}