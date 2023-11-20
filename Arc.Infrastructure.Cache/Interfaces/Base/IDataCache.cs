namespace Arc.Infrastructure.Cache.Interfaces.Base;

public interface IDataCache
{
    T? Read<T>(
        string key
    )
        where T : class;

    void Set<T>(
        string key,
        T value,
        int? slidingExpirationMinutes = default
    )
        where T : class;

    void Delete(
        string key
    );
}