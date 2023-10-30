using Arc.Infrastructure.Common.Enums;

namespace Arc.Facades.Domain.Filters.Interfaces;

public interface IOperatingModeFilterFacade
{
    Task<ServiceModeType> GetCurrentMode();
}