using Arc.Criteria.Implementations;
using Arc.Database.Context;
using Arc.Infrastructure.Common.Enums;
using Arc.Infrastructure.Common.Models;
using Arc.Infrastructure.Repositories.Read.Implementations.Base;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Repositories.Read.Implementations;

public sealed class ServiceModesReadRepository(
    ArcDatabaseContext context
) :
    IdReadRepositoryBase
    <
        ServiceMode
    >(
        context
    ),
    IServiceModesReadRepository
{
    public async Task<ServiceMode?> GetCurrent()
    {
        var orderingParam =
            new OrderingParam<ServiceMode>(
                OrderingType.Descending,
                mode =>
                    mode.UpdateDateTime
            );

        var criteria =
            new ReadRepositoryFiltersCriteria<ServiceMode>();

        criteria
            .SetOrdering(
                orderingParam
            );

        return
            await
                GetFirstByCriteriaAsync(
                    criteria
                );
    }
}