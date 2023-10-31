namespace Arc.Infrastructure.Transactions.Interfaces;

public interface ITransaction :
    IDisposable
{
    Task Commit(
        params Type[] updatedEntityTypes
    );

    void Rollback();
}