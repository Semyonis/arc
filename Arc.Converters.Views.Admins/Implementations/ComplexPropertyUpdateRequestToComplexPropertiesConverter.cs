using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class ComplexPropertyUpdateRequestToComplexPropertiesConverter :
    ConverterBase
    <
        ComplexPropertyUpdateRequest,
        ComplexProperty
    >,
    IComplexPropertyUpdateRequestToComplexPropertiesConverter
{
    private readonly IStringToComplexPropertyDescriptionConverter
        _descriptionToDescriptionEntityConverter;

    public ComplexPropertyUpdateRequestToComplexPropertiesConverter(
        IStringToComplexPropertyDescriptionConverter
            descriptionToDescriptionEntityConverter
    ) =>
        _descriptionToDescriptionEntityConverter =
            descriptionToDescriptionEntityConverter;

    public override ComplexProperty Convert(
        ComplexPropertyUpdateRequest entity
    )
    {
        var description =
            _descriptionToDescriptionEntityConverter
                .Convert(
                    entity
                        .Description
                        .Value
                );

        return
            new()
            {
                Id = entity.Id,
                GroupId = entity.Group.Id,
                Value = entity.Name,
                Description = description,
            };
    }
}