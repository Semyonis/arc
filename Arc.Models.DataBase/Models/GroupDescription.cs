namespace Arc.Models.DataBase.Models;

public sealed class GroupDescription :
    BaseDescription
{
    public int GroupId { get; set; }

    public Group Group { get; set; }
}