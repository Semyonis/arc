using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

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