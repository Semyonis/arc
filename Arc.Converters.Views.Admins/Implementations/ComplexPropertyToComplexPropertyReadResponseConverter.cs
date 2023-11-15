using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class ComplexPropertyToComplexPropertyReadResponseConverter(
    IGroupToGroupReadResponseConverter
        testToGroupReadResponseConverter,
    IComplexPropertyDescriptionToDescriptionResponseConverter
        complexPropertyDescriptionToDescriptionResponseConverter
) : ConverterBase
    <
        ComplexProperty,
        ComplexPropertyReadResponse
    >,
    IComplexPropertyToComplexPropertyReadResponseConverter
{
    public override ComplexPropertyReadResponse Convert(
        ComplexProperty entity
    )
    {
        var description =
            complexPropertyDescriptionToDescriptionResponseConverter
                .Convert(
                    entity.Description
                );

        var test =
            testToGroupReadResponseConverter
                .Convert(
                    entity.Group
                );

        return new(
            entity.Id,
            entity.Value,
            description,
            test
        );
    }
}