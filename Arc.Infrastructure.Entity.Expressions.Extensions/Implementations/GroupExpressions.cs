using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class GroupExpressions
{
    public static Expression<Func<Group, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<Group, string>> GetName() =>
        entity =>
            entity.Name;

    public static Expression<Func<Group, int>> GetDescriptionId() =>
        entity =>
            entity.DescriptionId;

    public static Expression<Func<Group, GroupDescription>> GetDescription() =>
        entity =>
            entity.Description;

    public static Expression<Func<Group, ICollection<ComplexProperty>>> GetComplexProperties() =>
        entity =>
            entity.ComplexProperties;
}