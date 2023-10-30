using Arc.Models.DataBase.Models;

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