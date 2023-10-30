using Arc.Converters.Base.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Interfaces;

public interface IGroupModelToListItemResponseConverter :
    IConverterBase
    <
        GroupModel,
        ListItemResponse
    > { }