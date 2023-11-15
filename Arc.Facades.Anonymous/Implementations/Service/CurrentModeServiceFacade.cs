using Arc.Facades.Anonymous.Interfaces.Service;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Common.Models;

namespace Arc.Facades.Anonymous.Implementations.Service;

public sealed class CurrentModeServiceFacade(
    IResponsesDomainFacade
        internalFacade,
    IServiceModesReadRepository
        serviceModesReadRepository
) : ICurrentModeServiceFacade
{
    public async Task<Response> Execute()
    {
        var currentMode =
            await
                serviceModesReadRepository
                    .GetCurrent();

        var currentState =
            currentMode?.Mode
            ?? ServiceModeType.On;

        var response =
            new CurrentModeResponse(
                currentState
            );

        return
            internalFacade
                .CreateOkResponse(
                    response
                );
    }
}