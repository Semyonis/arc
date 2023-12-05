using Arc.Criteria.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Database.Context;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Repositories.Read.Implementations.Base;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Database.Entities.Models;

using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.UserExpressions;

namespace Arc.Infrastructure.Repositories.Read.Implementations;

public sealed class UsersReadRepository(
    ArcDatabaseContext context,
    IUserPropertyFilters
        userPropertyFilters
) : IdReadRepositoryBase<User>(
        context
    ),
    IUsersReadRepository
{
    public async Task<string?> GetEmailById(
        int userId
    ) =>
        await
            GetProjectionById(
                userId,
                GetEmail()
            );

    public async Task<User?> GetByEmail(
        string email,
        Func
        <
            IQueryable<User>,
            IIncludableQueryable<User, object>
        >? include = null,
        bool asNoTracking = true
    )
    {
        var propertyFilterParameter =
            userPropertyFilters
                .GetEmailEqualFilter(
                    email
                );

        var criteria =
            new ReadRepositoryFiltersCriteria<User>
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