using System;

using Arc.Dependencies.Cache.Interfaces.Base;
using Arc.Infrastructure.Common.Extensions;

namespace Arc.Dependencies.Cache.Implementations.Base;

public abstract class CacheBase<TKey, TEntity> :
    ICacheBase<TKey, TEntity>
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
            _distributedCache
                .GetString(
                    strKey
                );

        if (resultJson.IsEmpty())
        {
            _distributedCache
                .Remove(
                    strKey
                );

            return default;
        }

        var result =
            _serializationDecorator
                .Deserialize<TEntity>(
                    resultJson
                );

        if (result == default)
        {
            _distributedCache
                .Remove(
                    strKey
                );

            return default;
        }

        _distributedCache
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
            _serializationDecorator
                .Serialize(
                    response
                );

        options ??=
            _defaultOptions;

        _distributedCache
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

        _distributedCache
            .Remove(
                strKey
            );
    }

    protected abstract string GetKey(
        TKey key
    );

#region Constructor

    private readonly IDistributedCache
        _distributedCache;

    private readonly ISerializationDecorator
        _serializationDecorator;

    protected CacheBase(
        IDistributedCache
            distributedCache,
        ISerializationDecorator
            serializationDecorator
    )
    {
        _distributedCache =
            distributedCache;

        _serializationDecorator =
            serializationDecorator;
    }

#endregion
}