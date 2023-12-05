using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class UserExpressions
{
    public static Expression<Func<User, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<User, string>> GetFirstName() =>
        entity =>
            entity.FirstName;

    public static Expression<Func<User, string>> GetLastName() =>
        entity =>
            entity.LastName;

    public static Expression<Func<User, string>> GetEmail() =>
        entity =>
            entity.Email;

    public static Expression<Func<User, ICollection<Item>>> GetItems() =>
        entity =>
            entity.Items;

    public static Expression<Func<User, string>> GetDiscriminator() =>
        entity =>
            entity.Discriminator;
}