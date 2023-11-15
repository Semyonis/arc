using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Controllers.Admins.Tables.Implementations.Groups;

[ControllerGroup(
    "Groups"
)]
public sealed class GroupsTableUpdateController(
    IGroupsTableUpdateFacade
        facade
) :
    BaseTableAuthorizedUpdateController
    <
        GroupTableUpdateRequest
    >(
        facade
    );