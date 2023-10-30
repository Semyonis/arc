namespace Arc.Models.DataBase.Models;

public sealed class User :
    Actor
{
    public ICollection<Item> Items { get; set; }
}