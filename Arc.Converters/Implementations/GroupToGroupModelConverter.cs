using Arc.Converters.Views.Common.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Converters.Implementations;

public sealed class GroupToGroupModelConverter(
        IBaseDescriptionToDescriptionModelConverter
            descriptionModelConverter
    )
    :
        ConverterBase
        <
            Group,
            GroupModel
        >,
        IGroupToGroupModelConverter
{
    public override GroupModel Convert(
        Group entity
    )
    {
        var descriptionModel =
            descriptionModelConverter
                .Convert(
                    entity.Description
                );

        return new(
            entity.Id,
            entity.Name,
            descriptionModel
        );
    }
}