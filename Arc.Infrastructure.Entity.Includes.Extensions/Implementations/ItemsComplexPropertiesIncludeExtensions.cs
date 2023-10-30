using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Entity.Includes.Extensions.Implementations;

public static class ItemsComplexPropertiesIncludeExtensions
{
    public static IIncludableQueryable<ItemsComplexProperties, ComplexProperty> IncludeComplexProperty(
        this IQueryable<ItemsComplexProperties> queryable
    ) =>
        queryable
            .Include(
                ItemsComplexPropertiesExpressions.GetComplexProperty()
            );

    public static IIncludableQueryable<ItemsComplexProperties, Group> IncludeComplexPropertyGroup(
        this IQueryable<ItemsComplexProperties> queryable
    ) =>
        queryable
            .IncludeComplexProperty()
            .ThenInclude(
                ComplexPropertyExpressions.GetGroup()
            );
}