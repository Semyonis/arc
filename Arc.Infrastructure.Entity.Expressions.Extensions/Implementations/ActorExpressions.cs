using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class ActorExpressions
{
    public static Expression<Func<Actor, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<Actor, string>> GetFirstName() =>
        entity =>
            entity.FirstName;

    public static Expression<Func<Actor, string>> GetLastName() =>
        entity =>
            entity.LastName;

    public static Expression<Func<Actor, string>> GetEmail() =>
        entity =>
            entity.Email;

    public static Expression<Func<Actor, string>> GetDiscriminator() =>
        entity =>
            entity.Discriminator;
}