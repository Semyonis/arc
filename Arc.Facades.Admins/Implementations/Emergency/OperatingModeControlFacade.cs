using Arc.Converters.Views.Admins.Interfaces;
using Arc.Facades.Admins.Interfaces.Emergency;
using Arc.Facades.Domain.Interface;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Emergency;

public sealed class OperatingModeControlFacade :
    IOperatingModeControlFacade
{
    public async Task<Response> Execute(
        AdminIdentity identity
    )
    {
        var responseModel =
            await
                _internalModeControlFacade
                    .GetDetailedCurrentMode();

        var response =
            _serviceModeModeModelToServiceModeAdminReadResponseConverter
                .Convert(
                    responseModel
                );

        return
            _internalFacade
                .CreateOkResponse(
                    response
                );
    }

#region Constructor

    private readonly IModeControlDetailedDomainFacade
        _internalModeControlFacade;

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly
        IServiceModeModelToServiceModeAdminReadResponseConverter
        _serviceModeModeModelToServiceModeAdminReadResponseConverter;

    public OperatingModeControlFacade(
        IModeControlDetailedDomainFacade
            internalModeControlFacade,
        IResponsesDomainFacade
            internalFacade,
        IServiceModeModelToServiceModeAdminReadResponseConverter
            serviceModeModeModelToServiceModeAdminReadResponseConverter
    )
    {
        _internalModeControlFacade =
            internalModeControlFacade;

        _internalFacade =
            internalFacade;

        _serviceModeModeModelToServiceModeAdminReadResponseConverter =
            serviceModeModeModelToServiceModeAdminReadResponseConverter;
    }

#endregion
}