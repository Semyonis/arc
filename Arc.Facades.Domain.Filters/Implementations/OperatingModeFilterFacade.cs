using Arc.Facades.Domain.Filters.Interfaces;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Repositories.Read.Interfaces;

namespace Arc.Facades.Domain.Filters.Implementations;

public sealed class OperatingModeFilterFacade(
        IServiceModesReadRepository
            serviceModesReadRepository
    )
    :
        IOperatingModeFilterFacade
{
#region Constructor

#endregion

    public async Task<ServiceModeType> GetCurrentMode()
    {
        var currentMode =
            await
                serviceModesReadRepository
                    .GetCurrent();

        return
            currentMode?.Mode
            ?? ServiceModeType.On;
    }
}