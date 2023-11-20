using System;

using Arc.Infrastructure.Cache.Interfaces.Base;
using Arc.Infrastructure.Common.Extensions;

namespace Arc.Infrastructure.Cache.Implementations;

public sealed class DataCache(
    IDistributedCache
        cache,
    ISerializationDecorator
        serializationDecorator
) : IDataCache
{
    public T? Read<T>(
        string key
    )
        where T : class
    {
        var resultJson =
            cache
                .GetString(
                    key
                );

        if (resultJson.IsEmpty())
        {
            return default;
        }

        cache
            .Refresh(
                key
            );

        return
            serializationDecorator
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
            serializationDecorator
                .Serialize(
                    value
                );

        var options =
            GetOptions(
                slidingExpirationMinutes
            );

        cache
            .SetString(
                key,
                responseJson,
                options
            );
    }

    public void Delete(
        string key
    ) =>
        cache
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
}