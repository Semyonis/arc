using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class ComplexPropertyExpressions
{
    public static Expression<Func<ComplexProperty, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<ComplexProperty, string>> GetValue() =>
        entity =>
            entity.Value;

    public static Expression<Func<ComplexProperty, int>> GetGroupId() =>
        entity =>
            entity.GroupId;

    public static Expression<Func<ComplexProperty, Group>> GetGroup() =>
        entity =>
            entity.Group;

    public static Expression<Func<ComplexProperty, int>> GetDescriptionId() =>
        entity =>
            entity.DescriptionId;

    public static Expression<Func<ComplexProperty, ComplexPropertyDescription>> GetDescription() =>
        entity =>
            entity.Description;
}