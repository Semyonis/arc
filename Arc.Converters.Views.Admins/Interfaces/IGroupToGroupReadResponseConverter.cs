using Arc.Converters.Base.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Converters.Views.Admins.Interfaces;

public interface IGroupToGroupReadResponseConverter :
    IConverterBase
    <
        Group,
        GroupReadResponse
    >;