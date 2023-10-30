using Arc.Converters.Base.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Models;

namespace Arc.Converters.Views.Admins.Interfaces;

public interface IAdminToAdminInfoResponseConverter :
    IConverterBase
    <
        Admin,
        AdminResponse
    > { }