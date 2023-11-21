using System.Threading.Tasks;

using Arc.Infrastructure.Common.Models;

using StackExchange.Redis;

namespace Arc.Dependencies.RedisStack.Interfaces;

public interface IJsonCommandsService
{
    bool Set<TEntity>(
        IDatabase inMemoryDatabase,
        string key,
        TEntity value
    );

    ResultContainer<TEntity> Get<TEntity>(
        IDatabase inMemoryDatabase,
        string key
    );

    Task Delete(
        IDatabase inMemoryDatabase,
        string key
    );
}