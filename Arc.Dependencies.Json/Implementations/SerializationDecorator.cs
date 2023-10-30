using Arc.Dependencies.Json.Interfaces;

namespace Arc.Dependencies.Json.Implementations;

public sealed class SerializationDecorator :
    ISerializationDecorator
{
    public TEntity? Deserialize<TEntity>(
        string json
    ) =>
        JsonSerializer
            .Deserialize<TEntity>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive =
                        true,
                }
            );

    public string Serialize<TEntity>(
        TEntity entity
    ) =>
        JsonSerializer
            .Serialize(
                entity
            );

    public ValueTask<TEntity?> DeserializeAsync<TEntity>(
        Stream stream
    ) =>
        JsonSerializer
            .DeserializeAsync<TEntity>(
                stream,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive =
                        true,
                }
            );
}