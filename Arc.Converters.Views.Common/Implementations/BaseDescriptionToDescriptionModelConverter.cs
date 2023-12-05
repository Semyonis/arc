using Arc.Models.BusinessLogic.Models;
using Arc.Database.Entities.Models;

namespace Arc.Converters.Views.Common.Implementations;

public sealed class BaseDescriptionToDescriptionModelConverter :
    ConverterBase
    <
        BaseDescription,
        DescriptionModel
    >,
    IBaseDescriptionToDescriptionModelConverter
{
    public override DescriptionModel Convert(
        BaseDescription entity
    ) =>
        new(
            entity.Id,
            entity.Value
        );
}