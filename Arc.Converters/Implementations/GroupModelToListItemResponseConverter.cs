using Arc.Models.BusinessLogic.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Implementations;

public sealed class GroupModelToListItemResponseConverter :
    ConverterBase
    <
        GroupModel,
        ListItemResponse
    >,
    IGroupModelToListItemResponseConverter
{
    public override ListItemResponse Convert(
        GroupModel entity
    ) =>
        new(
            entity.Id,
            entity.Name
        );
}