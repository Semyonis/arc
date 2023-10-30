using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Repositories.Read.Interfaces;

public interface IUsersReadRepository :
    IReadRepositoryBase<User>
{
    Task<string?> GetEmailById(
        int userId
    );

    Task<User?> GetByEmail(
        string email,
        Func
        <
            IQueryable<User>,
            IIncludableQueryable<User, object>
        >? include = default,
        bool asNoTracking = true
    );
}