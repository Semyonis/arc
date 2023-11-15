using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class GroupUpdateResponseToGroupsConverter(
        IStringToGroupDescriptionConverter
            descriptionToDescriptionEntityConverter
    )
    :
        ConverterBase
        <
            GroupUpdateResponse,
            Group
        >,
        IGroupUpdateResponseToGroupsConverter
{
    public override Group Convert(
        GroupUpdateResponse entity
    )
    {
        var description =
            descriptionToDescriptionEntityConverter
                .Convert(
                    entity
                        .Description
                        .Value
                );

        return
            new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = description,
            };
    }
}