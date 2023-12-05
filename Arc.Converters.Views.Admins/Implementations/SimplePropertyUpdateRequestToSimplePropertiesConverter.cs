using Arc.Converters.Views.Admins.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class SimplePropertyUpdateRequestToSimplePropertiesConverter :
    ConverterBase
    <
        SimplePropertyUpdateRequest,
        SimpleProperty
    >,
    ISimplePropertyUpdateRequestToSimplePropertiesConverter
{
    public override SimpleProperty Convert(
        SimplePropertyUpdateRequest entity
    ) =>
        new()
        {
            Id = entity.Id,
            Value = entity.Value,
        };
}