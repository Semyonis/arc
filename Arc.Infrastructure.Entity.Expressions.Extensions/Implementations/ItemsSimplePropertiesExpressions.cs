using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class ItemsSimplePropertiesExpressions
{
    public static Expression<Func<ItemsSimpleProperties, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<ItemsSimpleProperties, int>> GetSimplePropertyId() =>
        entity =>
            entity.SimplePropertyId;

    public static Expression<Func<ItemsSimpleProperties, int>> GetItemId() =>
        entity =>
            entity.ItemId;

    public static Expression<Func<ItemsSimpleProperties, SimpleProperty>> GetSimpleProperty() =>
        entity =>
            entity.SimpleProperty;

    public static Expression<Func<ItemsSimpleProperties, Item>> GetItem() =>
        entity =>
            entity.Item;
}