using Arc.Converters.Base.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.Views.Admins.Models;

namespace Arc.Converters.Views.Admins.Interfaces;

public interface IServiceModeModelToServiceModeAdminReadResponseConverter :
    IConverterBase
    <
        ServiceModeModel,
        ServiceModeAdminReadResponse
    > { }