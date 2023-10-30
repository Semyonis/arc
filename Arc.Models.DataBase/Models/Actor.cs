namespace Arc.Models.DataBase.Models;

public abstract class Actor :
    IWithIdentifier
{
    public string Discriminator { get; set; }

    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public int Id { get; set; }
}