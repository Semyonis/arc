namespace Arc.Infrastructure.Transactions.Interfaces;

public interface ITransaction :
    IDisposable
{
    Task Commit();

    void Rollback();
}