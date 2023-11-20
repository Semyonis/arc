using System.Net;

using Arc.Dependencies.ConfigurationSettings.Models;
using Arc.Dependencies.RedisStack.Interfaces;
using Arc.Infrastructure.Common.Extensions;

using StackExchange.Redis;

namespace Arc.Dependencies.RedisStack.Implementations;

public sealed class InMemoryDatabaseConnector :
    IInMemoryDatabaseConnector
{
    public IDatabase GetDatabase(
        RedisStackSettings redisStackSettings
    )
    {
        var redisStackPort =
            redisStackSettings
                .Port
                .ParseToNullableInteger()!
                .Value;

        var dnsEndPoint =
            new DnsEndPoint(
                redisStackSettings.Host,
                redisStackPort
            );

        var endPoints =
            (dnsEndPoint as EndPoint).WrapByList();

        var endPointCollection =
            new EndPointCollection(
                endPoints
            );

        var configurationOptions =
            new ConfigurationOptions
            {
                EndPoints = endPointCollection,
                AbortOnConnectFail = false,
            };

        var connectionMultiplexer =
            ConnectionMultiplexer
                .Connect(
                    configurationOptions
                );

        return
            connectionMultiplexer.GetDatabase();
    }
}