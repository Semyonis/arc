using Arc.Criteria.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Database.Context;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Repositories.Read.Implementations.Base;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Repositories.Read.Implementations;

public sealed class ActorsReadRepository(
    ArcDatabaseContext
        context,
    IActorPropertyFilters
        actorPropertyFilters
) : IdReadRepositoryBase
    <
        Actor
    >(
        context
    ),
    IActorsReadRepository
{
    public async Task<Actor?> GetByEmail(
        string email,
        Func
        <
            IQueryable<Actor>,
            IIncludableQueryable<Actor, object>
        >? include = default,
        bool asNoTracking = true
    )
    {
        var propertyFilterParameter =
            actorPropertyFilters
                .GetEmailEqualFilter(
                    email
                );

        var criteria =
            new ReadRepositoryFiltersCriteria<Actor>
            {
                Filters =
                    propertyFilterParameter.WrapByReadOnlyList(),
            };

        return
            await
                GetFirstByCriteriaAsync(
                    criteria,
                    include,
                    asNoTracking
                );
    }
}