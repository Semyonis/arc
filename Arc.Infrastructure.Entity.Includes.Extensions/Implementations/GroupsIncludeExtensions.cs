using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Entity.Includes.Extensions.Implementations;

public static class GroupsIncludeExtensions
{
    public static IIncludableQueryable<Group, GroupDescription>
        IncludeDescription(
            this IQueryable<Group> queryable
        ) =>
        queryable
            .Include(
                GroupExpressions.GetDescription()
            );
}