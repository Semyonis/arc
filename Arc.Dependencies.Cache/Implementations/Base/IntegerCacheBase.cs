namespace Arc.Dependencies.Cache.Implementations.Base;

public abstract class IntegerCacheBase<TEntity> :
    CacheBase<int, TEntity>
    where TEntity : class
{
    protected IntegerCacheBase(
        IDistributedCache
            distributedCache,
        ISerializationDecorator
            serializationDecorator
    ) : base(
        distributedCache,
        serializationDecorator
    ) { }

    protected override string GetKey(
        int key
    ) =>
        key.ToString();
}