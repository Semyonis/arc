using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.Groups;

namespace Arc.Controllers.Admins.Tables.Implementations.Groups;

[ControllerGroup(
    "Groups"
)]
public sealed class GroupsTableDeleteController(
    IGroupsTableDeleteFacade
        facade
) :
    BaseTableAuthorizedDeleteController(
        facade
    );