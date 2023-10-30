using static Arc.Infrastructure.Common.Constants.ControllerRouteTemplateConstants;

namespace Arc.Controllers.Base.Attributes;

public sealed class AdminApiRouteAttribute :
    RouteAttribute
{
    public AdminApiRouteAttribute() :
        base(
            $"{AdminRoutePrefix}{ControllerRoute}"
        ) { }
}