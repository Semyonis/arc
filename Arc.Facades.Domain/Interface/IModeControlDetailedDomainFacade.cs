using Arc.Models.BusinessLogic.Models;

namespace Arc.Facades.Domain.Interface;

public interface IModeControlDetailedDomainFacade
{
    Task<ServiceModeModel> GetDetailedCurrentMode();
}