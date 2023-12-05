namespace Arc.Database.Entities.Models;

public sealed class User :
    Actor
{
    public ICollection<Item> Items { get; set; }
}