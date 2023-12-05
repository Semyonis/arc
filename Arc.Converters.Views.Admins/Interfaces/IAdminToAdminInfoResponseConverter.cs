using Arc.Converters.Base.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Models.Views.Admins.Models;

namespace Arc.Converters.Views.Admins.Interfaces;

public interface IAdminToAdminInfoResponseConverter :
    IConverterBase
    <
        Admin,
        AdminResponse
    >;