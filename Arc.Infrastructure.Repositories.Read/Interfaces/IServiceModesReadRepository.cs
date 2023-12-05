using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Repositories.Read.Interfaces;

public interface IServiceModesReadRepository :
    IReadRepositoryBase<ServiceMode>
{
    Task<ServiceMode?> GetCurrent();
}