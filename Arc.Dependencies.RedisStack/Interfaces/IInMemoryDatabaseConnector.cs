using Arc.Infrastructure.ConfigurationSettings.Models;

using StackExchange.Redis;

namespace Arc.Dependencies.RedisStack.Interfaces;

public interface IInMemoryDatabaseConnector
{
    IDatabase GetDatabase(
        RedisStackSettings redisStackSettings
    );
}