using Arc.Criteria.Implementations;
using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Database.Context;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Repositories.Read.Implementations.Base;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.DataBase.Models;

using static Arc.Infrastructure.Entity.Expressions.Extensions.Implementations.AdminExpressions;

namespace Arc.Infrastructure.Repositories.Read.Implementations;

public sealed class AdminsReadRepository :
    IdReadRepositoryBase<Admin>,
    IAdminsReadRepository
{
    private readonly IAdminPropertyFilters
        _adminPropertyFilters;

    public AdminsReadRepository(
        ArcDatabaseContext context,
        IAdminPropertyFilters
            adminPropertyFilters
    ) : base(
        context
    ) =>
        _adminPropertyFilters =
            adminPropertyFilters;

    public async Task<Admin?> GetByEmail(
        string email,
        Func
        <
            IQueryable<Admin>,
            IIncludableQueryable<Admin, object>
        >? include = default,
        bool asNoTracking = true
    )
    {
        var propertyFilterParameter =
            _adminPropertyFilters
                .GetEmailEqualFilter(
                    email
                );

        var criteria =
            new ReadRepositoryFiltersCriteria<Admin>
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

    public async Task<string?> GetEmailById(
        int adminId
    )
    {
        var criteria =
            new ReadRepositoryEntityIdsCriteria<Admin>
            {
                Ids = adminId
                    .WrapByList(),
            };

        return
            await
                GetProjectionByCriteriaAsync(
                    criteria,
                    GetEmail()
                );
    }

    public async Task<IReadOnlyList<Admin>> GetAll(
        Func
        <
            IQueryable<Admin>,
            IIncludableQueryable<Admin, object>
        >? include = default,
        bool asNoTracking = true
    )
    {
        var criteria =
            new ReadRepositoryFiltersCriteria<Admin>();

        return
            await
                GetListByCriteriaAsync(
                    criteria,
                    include,
                    asNoTracking
                );
    }
}