using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;

namespace Arc.Controllers.Admins.Tables.Implementations.ComplexProperties;

[ControllerGroup(
    "ComplexProperties"
)]
public sealed class ComplexPropertiesTableDeleteController :
    BaseTableAuthorizedDeleteController
{
    public ComplexPropertiesTableDeleteController(
        IComplexPropertiesTableDeleteFacade
            facade
    ) : base(
        facade
    ) { }
}