using Arc.Models.DataBase.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Common.Implementations;

public abstract class BaseDescriptionResponseConverter<TEntity> :
    ConverterBase
    <
        TEntity,
        DescriptionResponse
    >,
    IBaseDescriptionResponseConverter<TEntity>
    where TEntity : BaseDescription
{
    public override DescriptionResponse Convert(
        TEntity entity
    ) =>
        new(
            entity.Id,
            entity.Value
        );
}