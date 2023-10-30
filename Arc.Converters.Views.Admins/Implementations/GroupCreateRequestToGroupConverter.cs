using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class GroupCreateRequestToGroupConverter :
    ConverterBase
    <
        GroupCreateRequest,
        Group
    >,
    IGroupCreateRequestToGroupConverter
{
    private readonly IDescriptionCreateRequestToGroupDescriptionConverter
        _descriptionCreateRequestToGroupDescriptionConverter;

    public GroupCreateRequestToGroupConverter(
        IDescriptionCreateRequestToGroupDescriptionConverter
            descriptionCreateRequestToGroupDescriptionConverter
    ) =>
        _descriptionCreateRequestToGroupDescriptionConverter =
            descriptionCreateRequestToGroupDescriptionConverter;

    public override Group Convert(
        GroupCreateRequest entityCreate
    )
    {
        var description =
            _descriptionCreateRequestToGroupDescriptionConverter
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