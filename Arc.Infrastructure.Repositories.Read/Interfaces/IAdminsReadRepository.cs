using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Repositories.Read.Interfaces;

public interface IAdminsReadRepository :
    IReadRepositoryBase<Admin>
{
    Task<Admin?> GetByEmail(
        string email,
        Func
        <
            IQueryable<Admin>,
            IIncludableQueryable<Admin, object>
        >? include = default,
        bool asNoTracking = true
    );

    Task<string?> GetEmailById(
        int adminId
    );

    Task<IReadOnlyList<Admin>> GetAll(
        Func
        <
            IQueryable<Admin>,
            IIncludableQueryable<Admin, object>
        >? include = default,
        bool asNoTracking = true
    );
}