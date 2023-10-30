namespace Arc.Models.DataBase.Models;

public sealed class ServiceMode :
    IWithIdentifier
{
    public required ServiceModeType Mode { get; set; }

    public required DateTime UpdateDateTime { get; set; }

    public required int UpdatedById { get; set; }

    public Admin UpdatedBy { get; set; }

    public int Id { get; set; }
}