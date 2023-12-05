using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class ItemExpressions
{
    public static Expression<Func<Item, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<Item, string>> GetName() =>
        entity =>
            entity.Name;

    public static Expression<Func<Item, DateTime>> GetDateCreated() =>
        entity =>
            entity.DateCreated;

    public static Expression<Func<Item, ICollection<ItemsSimpleProperties>>>
        GetSimplePropertyLinks() =>
        entity =>
            entity.SimplePropertyLinks;

    public static Expression<Func<Item, ICollection<ItemsComplexProperties>>>
        GetComplexPropertyLinks() =>
        entity =>
            entity.ComplexPropertyLinks;
}