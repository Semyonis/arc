using Arc.Models.DataBase.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Common.Implementations;

public abstract class BaseDescriptionCreateRequestConverter<TEntity> :
    ConverterBase
    <
        DescriptionCreateRequest,
        TEntity
    >,
    IBaseDescriptionCreateRequestConverter<TEntity>
    where TEntity : BaseDescription, new()
{
    public override TEntity Convert(
        DescriptionCreateRequest entity
    ) =>
        new()
        {
            Value = entity.Value,
        };
}