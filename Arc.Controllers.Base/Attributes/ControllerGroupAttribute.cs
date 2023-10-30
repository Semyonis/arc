namespace Arc.Controllers.Base.Attributes;

public sealed class ControllerGroupAttribute :
    ApiExplorerSettingsAttribute
{
    public ControllerGroupAttribute(
        string name
    ) =>
        GroupName =
            name;
}