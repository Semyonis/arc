using Arc.Converters.Views.Admins.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class ComplexPropertyCreateRequestToComplexPropertyConverter(
    IDescriptionCreateRequestToComplexPropertyDescriptionConverter
        descriptionCreateRequestToComplexPropertyDescriptionConverter
) : ConverterBase
    <
        ComplexPropertyCreateRequest,
        ComplexProperty>,
    IComplexPropertyCreateRequestToComplexPropertyConverter
{
    public override ComplexProperty Convert(
        ComplexPropertyCreateRequest entityCreate
    )
    {
        var description =
            descriptionCreateRequestToComplexPropertyDescriptionConverter
                .Convert(
                    entityCreate.Description
                );

        return new()
        {
            GroupId = entityCreate.Group.Id,

            Value = entityCreate.Name,

            Description = description,
        };
    }
}