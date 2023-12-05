using Arc.Models.BusinessLogic.Models;
using Arc.Database.Entities.Models;

namespace Arc.Converters.Implementations;

public sealed class SimplePropertyToItemSimplePropertyModelConverter :
    ConverterBase
    <
        SimpleProperty,
        SimplePropertyModel
    >,
    ISimplePropertyToItemSimplePropertyModelConverter
{
    public override SimplePropertyModel Convert(
        SimpleProperty entity
    ) =>
        new(
            entity.Id,
            entity.Value
        );
}