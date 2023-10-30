using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class SimplePropertyToSimplePropertyReadResponseConverter :
    ConverterBase
    <
        SimpleProperty,
        SimplePropertyReadResponse
    >,
    ISimplePropertyToSimplePropertyReadResponseConverter
{
    public override SimplePropertyReadResponse Convert(
        SimpleProperty entity
    ) =>
        new(
            entity.Id,
            entity.Value
        );
}