using Arc.Database.Entities.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Common.Implementations;

public sealed class AdminToListItemResponseConverter :
    ConverterBase
    <
        Admin,
        ListItemResponse
    >,
    IAdminToListItemResponseConverter
{
    public override ListItemResponse Convert(
        Admin entity
    ) =>
        new(
            entity.Id,
            entity.FirstName
        );
}