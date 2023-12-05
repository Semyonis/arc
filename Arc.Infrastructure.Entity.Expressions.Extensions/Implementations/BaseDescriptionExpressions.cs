using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class BaseDescriptionExpressions
{
    public static Expression<Func<BaseDescription, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<BaseDescription, string>> GetValue() =>
        entity =>
            entity.Value;
}