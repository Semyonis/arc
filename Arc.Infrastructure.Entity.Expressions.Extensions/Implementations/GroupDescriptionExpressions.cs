using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class GroupDescriptionExpressions
{
    public static Expression<Func<GroupDescription, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<GroupDescription, int>> GetGroupId() =>
        entity =>
            entity.GroupId;

    public static Expression<Func<GroupDescription, string>> GetValue() =>
        entity =>
            entity.Value;

    public static Expression<Func<GroupDescription, Group>> GetGroup() =>
        entity =>
            entity.Group;
}