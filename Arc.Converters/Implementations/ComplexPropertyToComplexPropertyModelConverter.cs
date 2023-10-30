using Arc.Converters.Views.Common.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Converters.Implementations;

public sealed class ComplexPropertyToComplexPropertyModelConverter :
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
            _testToGroupModelConverter
                .Convert(
                    entity.Group
                );

        var descriptionModel =
            _descriptionModelConverter
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

#region Constructor

    private readonly IBaseDescriptionToDescriptionModelConverter
        _descriptionModelConverter;

    private readonly IGroupToGroupModelConverter
        _testToGroupModelConverter;

    public ComplexPropertyToComplexPropertyModelConverter(
        IGroupToGroupModelConverter
            testToGroupModelConverter,
        IBaseDescriptionToDescriptionModelConverter
            descriptionModelConverter
    )
    {
        _testToGroupModelConverter =
            testToGroupModelConverter;

        _descriptionModelConverter =
            descriptionModelConverter;
    }

#endregion
}