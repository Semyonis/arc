using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class AdminExpressions
{
    public static Expression<Func<Admin, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<Admin, string>> GetFirstName() =>
        entity =>
            entity.FirstName;

    public static Expression<Func<Admin, string>> GetLastName() =>
        entity =>
            entity.LastName;

    public static Expression<Func<Admin, string>> GetEmail() =>
        entity =>
            entity.Email;

    public static Expression<Func<Admin, string>> GetDiscriminator() =>
        entity =>
            entity.Discriminator;
}