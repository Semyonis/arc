namespace Arc.Database.Entities.Models;

public abstract class BaseDescription :
    IWithIdentifier,
    IWithValue
{
    public int Id { get; set; }

    public string Value { get; set; }
}