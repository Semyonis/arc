namespace Arc.Database.Entities.Models;

public sealed class Group :
    IWithIdentifier,
    IWithName
{
    public int DescriptionId { get; set; }

    public GroupDescription Description { get; set; }

    public ICollection<ComplexProperty> ComplexProperties { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }
}