using Arc.Database.Entities.Models;

namespace Arc.Converters.Views.Common.Implementations;

public abstract class StringToDescriptionEntityConverter<TEntity> :
    ConverterBase
    <
        string,
        TEntity
    >,
    IStringToDescriptionEntityConverter<TEntity>
    where TEntity : BaseDescription, new()
{
    public override TEntity Convert(
        string entity
    ) =>
        new()
        {
            Value = entity,
        };
}