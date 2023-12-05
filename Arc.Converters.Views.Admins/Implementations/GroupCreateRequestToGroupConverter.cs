using Arc.Converters.Views.Admins.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class GroupCreateRequestToGroupConverter(
    IDescriptionCreateRequestToGroupDescriptionConverter
        descriptionCreateRequestToGroupDescriptionConverter
) : ConverterBase
    <
        GroupCreateRequest,
        Group
    >,
    IGroupCreateRequestToGroupConverter
{
    public override Group Convert(
        GroupCreateRequest entityCreate
    )
    {
        var description =
            descriptionCreateRequestToGroupDescriptionConverter
                .Convert(
                    entityCreate.Description
                );

        return
            new()
            {
                Name = entityCreate.Name,
                Description = description,
            };
    }
}