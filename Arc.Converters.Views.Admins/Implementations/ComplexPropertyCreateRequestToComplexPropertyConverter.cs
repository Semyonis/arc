using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class ComplexPropertyCreateRequestToComplexPropertyConverter :
    ConverterBase
    <
        ComplexPropertyCreateRequest,
        ComplexProperty>,
    IComplexPropertyCreateRequestToComplexPropertyConverter
{
    private readonly IDescriptionCreateRequestToComplexPropertyDescriptionConverter
        _descriptionCreateRequestToComplexPropertyDescriptionConverter;

    public ComplexPropertyCreateRequestToComplexPropertyConverter(
        IDescriptionCreateRequestToComplexPropertyDescriptionConverter
            descriptionCreateRequestToComplexPropertyDescriptionConverter
    ) =>
        _descriptionCreateRequestToComplexPropertyDescriptionConverter =
            descriptionCreateRequestToComplexPropertyDescriptionConverter;

    public override ComplexProperty Convert(
        ComplexPropertyCreateRequest entityCreate
    )
    {
        var description =
            _descriptionCreateRequestToComplexPropertyDescriptionConverter
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