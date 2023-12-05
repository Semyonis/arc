using Arc.Converters.Base.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Database.Entities.Models;

namespace Arc.Converters.Interfaces;

public interface IItemSimplePropertyToSimplePropertyPropertyModelConverter :
    IConverterBase
    <
        ItemsSimpleProperties,
        SimplePropertyModel
    >;