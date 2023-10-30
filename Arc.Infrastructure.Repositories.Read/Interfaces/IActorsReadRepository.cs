using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Repositories.Read.Interfaces;

public interface IActorsReadRepository :
    IReadRepositoryBase<Actor>
{
    Task<Actor?> GetByEmail(
        string email,
        Func
        <
            IQueryable<Actor>,
            IIncludableQueryable<Actor, object>
        >? include = default,
        bool asNoTracking = true
    );
}