using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class ItemsComplexPropertiesExpressions
{
    public static Expression<Func<ItemsComplexProperties, int>> GetComplexPropertyId() =>
        entity =>
            entity.ComplexPropertyId;

    public static Expression<Func<ItemsComplexProperties, int>> GetItemId() =>
        entity =>
            entity.ItemId;

    public static Expression<Func<ItemsComplexProperties, ComplexProperty>> GetComplexProperty() =>
        entity =>
            entity.ComplexProperty;

    public static Expression<Func<ItemsComplexProperties, Item>> GetItem() =>
        entity =>
            entity.Item;
}