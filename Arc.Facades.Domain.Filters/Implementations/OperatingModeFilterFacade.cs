using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Repositories.Read.Interfaces;

namespace Arc.Facades.Domain.Filters.Implementations;

public sealed class OperatingModeFilterFacade :
    IOperatingModeFilterFacade
{
#region Constructor

    private readonly IServiceModesReadRepository
        _serviceModesReadRepository;

    public OperatingModeFilterFacade(
        IServiceModesReadRepository
            serviceModesReadRepository
    ) =>
        _serviceModesReadRepository =
            serviceModesReadRepository;

#endregion

    public async Task<ServiceModeType> GetCurrentMode()
    {
        var currentMode =
            await
                _serviceModesReadRepository
                    .GetCurrent();

        return
            currentMode?.Mode
            ?? ServiceModeType.On;
    }
}