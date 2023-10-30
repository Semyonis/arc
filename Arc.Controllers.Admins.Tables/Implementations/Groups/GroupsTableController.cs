using Arc.Controllers.Admins.Tables.Implementations.Base;
using Arc.Controllers.Base.Attributes;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Models.Views.Admins.Tables.Models.Groups;
using Arc.Models.Views.Common.Models;

using Microsoft.AspNetCore.Mvc;

namespace Arc.Controllers.Admins.Tables.Implementations.Groups;

[ControllerGroup(
    "Groups"
)]
public sealed class GroupsTableController :
    BaseTableAuthorizedController
{
    public GroupsTableController(
        IGroupsTableFacade
            facade
    ) : base(
        facade
    ) { }

    [HttpGet]
    [ProducesOkResponseType(
        typeof(IReadOnlyList<GroupReadResponse>)
    )]
    public override async Task<IActionResult> Read(
        [FromQuery]
        TableReadRequest request
    ) =>
        await
            Invoke(
                request
            );
}