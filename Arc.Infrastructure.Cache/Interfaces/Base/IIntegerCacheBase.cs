namespace Arc.Infrastructure.Cache.Interfaces.Base;

public interface IIntegerCacheBase<TEntity> :
    ICacheBase<int, TEntity>
    where TEntity : class;