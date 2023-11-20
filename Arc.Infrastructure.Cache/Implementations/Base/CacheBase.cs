using System;

using Arc.Infrastructure.Cache.Interfaces.Base;
using Arc.Infrastructure.Common.Extensions;

namespace Arc.Infrastructure.Cache.Implementations.Base;

public abstract class CacheBase<TKey, TEntity>(
    IDistributedCache
        distributedCache,
    ISerializationDecorator
        serializationDecorator
) : ICacheBase<TKey, TEntity>
    where TEntity : class
{
    private readonly DistributedCacheEntryOptions
        _defaultOptions =
            new()
            {
                SlidingExpiration =
                    TimeSpan
                        .FromMinutes(
                            30
                        ),
            };

    public TEntity? Read(
        TKey key
    )
    {
        var strKey =
            GetKey(
                key
            );

        var resultJson =
            distributedCache
                .GetString(
                    strKey
                );

        if (resultJson.IsEmpty())
        {
            distributedCache
                .Remove(
                    strKey
                );

            return default;
        }

        var result =
            serializationDecorator
                .Deserialize<TEntity>(
                    resultJson
                );

        if (result == default)
        {
            distributedCache
                .Remove(
                    strKey
                );

            return default;
        }

        distributedCache
            .Refresh(
                strKey
            );

        return
            result;
    }

    public void Set(
        TKey key,
        TEntity response,
        DistributedCacheEntryOptions? options = default
    )
    {
        var strKey =
            GetKey(
                key
            );

        var responseJson =
            serializationDecorator
                .Serialize(
                    response
                );

        options ??=
            _defaultOptions;

        distributedCache
            .SetString(
                strKey,
                responseJson,
                options
            );
    }

    public void Delete(
        TKey key
    )
    {
        var strKey =
            GetKey(
                key
            );

        distributedCache
            .Remove(
                strKey
            );
    }

    protected abstract string GetKey(
        TKey key
    );
}