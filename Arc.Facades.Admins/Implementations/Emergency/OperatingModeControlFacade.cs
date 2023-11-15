using Arc.Converters.Views.Admins.Interfaces;
using Arc.Facades.Admins.Interfaces.Emergency;
using Arc.Facades.Domain.Interface;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Emergency;

public sealed class OperatingModeControlFacade(
    IModeControlDetailedDomainFacade
        internalModeControlFacade,
    IResponsesDomainFacade
        internalFacade,
    IServiceModeModelToServiceModeAdminReadResponseConverter
        serviceModeModeModelToServiceModeAdminReadResponseConverter
) : IOperatingModeControlFacade
{
    public async Task<Response> Execute(
        AdminIdentity identity
    )
    {
        var responseModel =
            await
                internalModeControlFacade
                    .GetDetailedCurrentMode();

        var response =
            serviceModeModeModelToServiceModeAdminReadResponseConverter
                .Convert(
                    responseModel
                );

        return
            internalFacade
                .CreateOkResponse(
                    response
                );
    }
}