using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Models.Views.Admins.Tables.Models.Groups;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.Groups;

[ControllerGroup(
    "Groups"
)]
public sealed class GroupsTableDetailsController :
    BaseTableAuthorizedDetailsController
{
    public GroupsTableDetailsController(
        IGroupsTableDetailsFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpGet(
        "{entityId:int}"
    )]
    [ProducesOkResponseType(
        typeof(GroupReadResponse)
    )]
    public override async Task<IActionResult> GetById(
        int entityId
    ) =>
        await
            Invoke(
                entityId
            );
}