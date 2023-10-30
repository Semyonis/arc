using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class SimplePropertyCreateRequestToSimplePropertyConverter :
    ConverterBase
    <
        SimplePropertyCreateRequest,
        SimpleProperty
    >,
    ISimplePropertyCreateRequestToSimplePropertyConverter
{
    public override SimpleProperty Convert(
        SimplePropertyCreateRequest entity
    ) =>
        new()
        {
            Id = entity.Id,
            Value = entity.Value,
        };
}