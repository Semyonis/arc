using Arc.Criteria.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Database.Context;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Repositories.Read.Implementations.Base;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Repositories.Read.Implementations;

public sealed class ActorsReadRepository :
    IdReadRepositoryBase
    <
        Actor
    >,
    IActorsReadRepository
{
    private readonly IActorPropertyFilters
        _actorPropertyFilters;

    public ActorsReadRepository(
        ArcDatabaseContext context,
        IActorPropertyFilters
            actorPropertyFilters
    ) : base(
        context
    ) =>
        _actorPropertyFilters =
            actorPropertyFilters;

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
            _actorPropertyFilters
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