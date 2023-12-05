namespace Arc.Database.Entities.Models;

public sealed class Item :
    IWithIdentifier,
    IWithName
{
    public required DateTime DateCreated { get; set; }

    public ICollection<ItemsSimpleProperties> SimplePropertyLinks { get; set; }

    public ICollection<ItemsComplexProperties> ComplexPropertyLinks { get; set; }

    public int Id { get; set; }

    public required string Name { get; set; }
}