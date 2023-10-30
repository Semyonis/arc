using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Entity.Includes.Extensions.Implementations;

public static class ItemSimplePropertyIncludeExtensions
{
    public static IIncludableQueryable<ItemsSimpleProperties, SimpleProperty> IncludeSimplePropertyLinks(
        this IQueryable<ItemsSimpleProperties> queryable
    ) =>
        queryable
            .Include(
                ItemsSimplePropertiesExpressions.GetSimpleProperty()
            );

    public static IIncludableQueryable<ItemsSimpleProperties, Item> IncludeItemLinks(
        this IQueryable<ItemsSimpleProperties> queryable
    ) =>
        queryable
            .Include(
                ItemsSimplePropertiesExpressions.GetItem()
            );
}