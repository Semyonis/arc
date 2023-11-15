using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class GroupToGroupReadResponseConverter(
        IGroupDescriptionToDescriptionResponseConverter
            testDescriptionToDescriptionResponseConverter
    )
    :
        ConverterBase
        <
            Group,
            GroupReadResponse
        >,
        IGroupToGroupReadResponseConverter
{
    public override GroupReadResponse Convert(
        Group entity
    )
    {
        var description =
            testDescriptionToDescriptionResponseConverter
                .Convert(
                    entity.Description
                );

        return new(
            entity.Id,
            entity.Name,
            description
        );
    }
}