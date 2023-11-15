using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;

namespace Arc.Controllers.Admins.Tables.Implementations.SimpleProperties;

[ControllerGroup(
    "SimpleProperties"
)]
public sealed class SimplePropertiesTableDeleteController(
    ISimplePropertiesTableDeleteFacade
        facade
) : BaseTableAuthorizedDeleteController(
    facade
);