namespace Arc.Database.Entities.Models;

public sealed class ItemsSimpleProperties :
    IWithIdentifier
{
    public required int ItemId { get; set; }

    public Item Item { get; set; }

    public required int SimplePropertyId { get; set; }

    public SimpleProperty SimpleProperty { get; set; }

    public int Id { get; set; }
}