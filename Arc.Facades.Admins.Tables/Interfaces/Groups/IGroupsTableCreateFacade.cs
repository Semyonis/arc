using Arc.Facades.Admins.Tables.Interfaces.Base;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Facades.Admins.Tables.Interfaces.Groups;

public interface IGroupsTableCreateFacade :
    IExtendedTableCreateFacade<GroupTableCreateRequest> { }