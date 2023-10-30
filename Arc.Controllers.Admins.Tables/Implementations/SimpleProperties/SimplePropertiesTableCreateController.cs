using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Controllers.Admins.Tables.Implementations.SimpleProperties;

[ControllerGroup(
    "SimpleProperties"
)]
public sealed class SimplePropertiesTableCreateController :
    BaseTableAuthorizedCreateController<SimplePropertyTableCreateRequest>
{
    public SimplePropertiesTableCreateController(
        ISimplePropertiesTableCreateFacade
            facade
    ) : base(
        facade
    ) { }
}