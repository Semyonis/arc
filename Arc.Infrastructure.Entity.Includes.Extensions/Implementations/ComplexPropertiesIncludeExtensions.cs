using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Entity.Includes.Extensions.Implementations;

public static class ComplexPropertiesIncludeExtensions
{
    public static IIncludableQueryable<ComplexProperty, ComplexPropertyDescription>
        IncludeDescription(
            this IQueryable<ComplexProperty> queryable
        ) =>
        queryable
            .Include(
                ComplexPropertyExpressions.GetDescription()
            );

    public static IIncludableQueryable<ComplexProperty, Group> IncludeGroup(
        this IQueryable<ComplexProperty> queryable
    ) =>
        queryable
            .Include(
                ComplexPropertyExpressions.GetGroup()
            );

    public static IIncludableQueryable<ComplexProperty, GroupDescription>
        IncludeGroupDescription(
            this IQueryable<ComplexProperty> queryable
        ) =>
        queryable
            .IncludeGroup()
            .ThenInclude(
                GroupExpressions.GetDescription()
            );
}