using Arc.Models.BusinessLogic.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Implementations;

public sealed class SimplePropertyModelToListItemResponseConverter :
    ConverterBase
    <
        SimplePropertyModel,
        ListItemResponse
    >,
    ISimplePropertyModelToListItemResponseConverter
{
    public override ListItemResponse Convert(
        SimplePropertyModel entity
    ) =>
        new(
            entity.Id,
            entity.Value
        );
}