namespace Arc.Infrastructure.Cache.Implementations.Base;

public abstract class IntegerCacheBase<TEntity>(
    IDistributedCache
        distributedCache,
    ISerializationDecorator
        serializationDecorator
) : CacheBase<int, TEntity>(
    distributedCache,
    serializationDecorator
)
    where TEntity : class
{
    protected override string GetKey(
        int key
    ) =>
        key.ToString();
}