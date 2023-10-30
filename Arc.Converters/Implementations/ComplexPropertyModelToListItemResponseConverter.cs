using Arc.Models.BusinessLogic.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Implementations;

public sealed class ComplexPropertyModelToListItemResponseConverter :
    ConverterBase
    <
        ComplexPropertyModel,
        ListItemResponse
    >,
    IComplexPropertyModelToListItemResponseConverter
{
    public override ListItemResponse Convert(
        ComplexPropertyModel entity
    ) =>
        new(
            entity.Id,
            entity.Value
        );
}