using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class SimplePropertyExpressions
{
    public static Expression<Func<SimpleProperty, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<SimpleProperty, string>> GetValue() =>
        entity =>
            entity.Value;

    public static Expression<Func<SimpleProperty, ICollection<ItemsSimpleProperties>>>
        GetItemLinks() =>
        entity =>
            entity.ItemLinks;
}