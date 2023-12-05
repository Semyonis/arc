namespace Arc.Database.Entities.Models;

public sealed class ItemsComplexProperties :
    IWithIdentifier
{
    public required int ItemId { get; set; }

    public Item Item { get; set; }

    public required int ComplexPropertyId { get; set; }

    public ComplexProperty ComplexProperty { get; set; }

    public int Id { get; set; }
}