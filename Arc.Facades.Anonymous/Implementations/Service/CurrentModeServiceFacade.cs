using Arc.Facades.Anonymous.Interfaces.Service;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Common.Models;

namespace Arc.Facades.Anonymous.Implementations.Service;

public sealed class CurrentModeServiceFacade :
    ICurrentModeServiceFacade
{
    public async Task<Response> Execute()
    {
        var currentMode =
            await
                _serviceModesReadRepository
                    .GetCurrent();

        var currentState =
            currentMode?.Mode
            ?? ServiceModeType.On;

        var response =
            new CurrentModeResponse(
                currentState
            );

        return
            _internalFacade
                .CreateOkResponse(
                    response
                );
    }

#region Constructor

    private readonly IServiceModesReadRepository
        _serviceModesReadRepository;

    private readonly IResponsesDomainFacade
        _internalFacade;

    public CurrentModeServiceFacade(
        IResponsesDomainFacade
            internalFacade,
        IServiceModesReadRepository
            serviceModesReadRepository
    )
    {
        _internalFacade =
            internalFacade;

        _serviceModesReadRepository =
            serviceModesReadRepository;
    }

#endregion
}