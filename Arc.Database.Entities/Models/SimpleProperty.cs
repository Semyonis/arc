namespace Arc.Database.Entities.Models;

public sealed class SimpleProperty :
    IWithIdentifier,
    IWithValue
{
    public ICollection<ItemsSimpleProperties> ItemLinks { get; set; }

    public int Id { get; set; }

    public required string Value { get; set; }
}