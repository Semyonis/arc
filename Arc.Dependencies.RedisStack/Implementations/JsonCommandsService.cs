using Arc.Dependencies.RedisStack.Interfaces;
using Arc.Infrastructure.Common.Models;

using NRedisStack.RedisStackCommands;

using StackExchange.Redis;

namespace Arc.Dependencies.RedisStack.Implementations;

public sealed class JsonCommandsService :
    IJsonCommandsService
{
    public bool Set<TEntity>(
        IDatabase inMemoryDatabase,
        string key,
        TEntity value
    )
    {
        var jsonCommands =
            inMemoryDatabase.JSON();

        var redisKey =
            new RedisKey(
                key
            );

        var redisValue =
            new RedisValue(
                "$"
            );

        return
            jsonCommands
                .Set(
                    redisKey,
                    redisValue,
                    value
                );
    }

    public ResultContainer<TEntity> Get<TEntity>(
        IDatabase inMemoryDatabase,
        string key
    )
    {
        var isCached =
            inMemoryDatabase
                .KeyExists(
                    key
                );

        if (!isCached)
        {
            return
                ResultContainer<TEntity>.Failed();
        }

        var jsonCommands =
            inMemoryDatabase.JSON();

        var result =
            jsonCommands
            .Get<TEntity>(
                key
            );

        return
            ResultContainer<TEntity>
                .Successful(
                    result!
                );
    }
    
}