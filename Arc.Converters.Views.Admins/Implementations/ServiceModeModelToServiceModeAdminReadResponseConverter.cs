using Arc.Converters.Views.Admins.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.Views.Admins.Models;

namespace Arc.Converters.Views.Admins.Implementations;

public sealed class ServiceModeModelToServiceModeAdminReadResponseConverter :
        ConverterBase
        <
            ServiceModeModel,
            ServiceModeAdminReadResponse
        >,
        IServiceModeModelToServiceModeAdminReadResponseConverter
{
    public override ServiceModeAdminReadResponse Convert(
        ServiceModeModel entity
    ) =>
        new(
            entity.Mode,
            entity.ModeSettingDate,
            entity.AdminId,
            entity.AdminEmail
        );
}