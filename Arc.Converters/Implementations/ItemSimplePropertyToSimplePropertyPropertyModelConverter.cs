using Arc.Models.BusinessLogic.Models;
using Arc.Database.Entities.Models;

namespace Arc.Converters.Implementations;

public sealed class ItemSimplePropertyToSimplePropertyPropertyModelConverter(
    ISimplePropertyToItemSimplePropertyModelConverter
        breedToItemSimplePropertyModelConverter
) : ConverterBase
    <
        ItemsSimpleProperties,
        SimplePropertyModel
    >,
    IItemSimplePropertyToSimplePropertyPropertyModelConverter
{
    public override SimplePropertyModel Convert(
        ItemsSimpleProperties entity
    ) =>
        breedToItemSimplePropertyModelConverter
            .Convert(
                entity.SimpleProperty
            );
}