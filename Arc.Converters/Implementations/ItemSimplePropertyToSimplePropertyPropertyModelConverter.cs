using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Converters.Implementations;

public sealed class ItemSimplePropertyToSimplePropertyPropertyModelConverter :
    ConverterBase
    <
        ItemsSimpleProperties,
        SimplePropertyModel
    >,
    IItemSimplePropertyToSimplePropertyPropertyModelConverter
{
    private readonly ISimplePropertyToItemSimplePropertyModelConverter
        _breedToItemSimplePropertyModelConverter;

    public ItemSimplePropertyToSimplePropertyPropertyModelConverter(
        ISimplePropertyToItemSimplePropertyModelConverter
            breedToItemSimplePropertyModelConverter
    ) =>
        _breedToItemSimplePropertyModelConverter =
            breedToItemSimplePropertyModelConverter;

    public override SimplePropertyModel Convert(
        ItemsSimpleProperties entity
    ) =>
        _breedToItemSimplePropertyModelConverter
            .Convert(
                entity.SimpleProperty
            );
}