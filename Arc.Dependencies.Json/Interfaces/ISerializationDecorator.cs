namespace Arc.Dependencies.Json.Interfaces;

public interface ISerializationDecorator
{
    TEntity? Deserialize<TEntity>(
        string json
    );

    string Serialize<TEntity>(
        TEntity entity
    );

    ValueTask<TEntity?> DeserializeAsync<TEntity>(
        Stream stream
    );
}