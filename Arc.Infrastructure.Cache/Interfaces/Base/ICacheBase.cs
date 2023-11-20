namespace Arc.Infrastructure.Cache.Interfaces.Base;

public interface ICacheBase<in TKey, TEntity>
    where TEntity : class
{
    TEntity? Read(
        TKey key
    );

    void Set(
        TKey key,
        TEntity response,
        DistributedCacheEntryOptions? options = default
    );

    void Delete(
        TKey key
    );
}