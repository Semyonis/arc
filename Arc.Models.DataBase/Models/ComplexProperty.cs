namespace Arc.Models.DataBase.Models;

public sealed class ComplexProperty :
    IWithIdentifier
{
    public string Value { get; set; }

    public int DescriptionId { get; set; }

    public ComplexPropertyDescription Description { get; set; }

    public int GroupId { get; set; }

    public Group Group { get; set; }

    public int Id { get; set; }
}