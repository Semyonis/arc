using Arc.Converters.Views.Common.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Converters.Implementations;

public sealed class ComplexPropertyToComplexPropertyModelConverter(
        IGroupToGroupModelConverter
            testToGroupModelConverter,
        IBaseDescriptionToDescriptionModelConverter
            descriptionModelConverter
    )
    :
        ConverterBase
        <
            ComplexProperty,
            ComplexPropertyModel
        >,
        IComplexPropertyToComplexPropertyModelConverter
{
    public override ComplexPropertyModel Convert(
        ComplexProperty entity
    )
    {
        var testModel =
            testToGroupModelConverter
                .Convert(
                    entity.Group
                );

        var descriptionModel =
            descriptionModelConverter
                .Convert(
                    entity.Description
                );

        return
            new(
                entity.Id,
                entity.Value,
                testModel,
                descriptionModel
            );
    }
}