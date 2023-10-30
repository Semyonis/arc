namespace Arc.Models.DataBase.Models;

public sealed class ComplexPropertyDescription :
    BaseDescription
{
    public int ComplexPropertyId { get; set; }

    public ComplexProperty ComplexProperty { get; set; }
}