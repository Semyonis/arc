using Arc.Converters.Views.Common.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Converters.Implementations;

public sealed class GroupToGroupModelConverter :
    ConverterBase
    <
        Group,
        GroupModel
    >,
    IGroupToGroupModelConverter
{
    private readonly IBaseDescriptionToDescriptionModelConverter
        _descriptionModelConverter;

    public GroupToGroupModelConverter(
        IBaseDescriptionToDescriptionModelConverter
            descriptionModelConverter
    ) =>
        _descriptionModelConverter =
            descriptionModelConverter;

    public override GroupModel Convert(
        Group entity
    )
    {
        var descriptionModel =
            _descriptionModelConverter
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