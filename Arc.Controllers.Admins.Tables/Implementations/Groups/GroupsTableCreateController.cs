using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Controllers.Admins.Tables.Implementations.Groups;

[ControllerGroup(
    "Groups"
)]
public sealed class GroupsTableCreateController :
    BaseTableAuthorizedCreateController<GroupTableCreateRequest>
{
    public GroupsTableCreateController(
        IGroupsTableCreateFacade
            facade
    ) : base(
        facade
    ) { }
}