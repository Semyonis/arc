using System;

using Arc.Dependencies.Cache.Interfaces.Base;
using Arc.Infrastructure.Common.Extensions;

namespace Arc.Dependencies.Cache.Implementations;

public sealed class DataCache :
    IDataCache
{
    public T? Read<T>(
        string key
    )
        where T : class
    {
        var resultJson =
            _cache
                .GetString(
                    key
                );

        if (resultJson.IsEmpty())
        {
            return default;
        }

        _cache
            .Refresh(
                key
            );

        return
            _serializationDecorator
                .Deserialize<T>(
                    resultJson
                );
    }

    public void Set<T>(
        string key,
        T value,
        int? slidingExpirationMinutes = default
    )
        where T : class
    {
        var responseJson =
            _serializationDecorator
                .Serialize(
                    value
                );

        var options =
            GetOptions(
                slidingExpirationMinutes
            );

        _cache
            .SetString(
                key,
                responseJson,
                options
            );
    }

    public void Delete(
        string key
    ) =>
        _cache
            .Remove(
                key
            );

    private static DistributedCacheEntryOptions GetOptions(
        int? slidingExpirationMinutes
    )
    {
        var options =
            new DistributedCacheEntryOptions();

        if (slidingExpirationMinutes.HasValue)
        {
            var slidingExpiration =
                TimeSpan
                    .FromMinutes(
                        slidingExpirationMinutes.Value
                    );

            options.SlidingExpiration =
                slidingExpiration;
        }

        return
            options;
    }

#region Constructor

    private readonly IDistributedCache
        _cache;

    private readonly ISerializationDecorator
        _serializationDecorator;

    public DataCache(
        IDistributedCache
            cache,
        ISerializationDecorator
            serializationDecorator
    )
    {
        _cache =
            cache;

        _serializationDecorator =
            serializationDecorator;
    }

#endregion
}