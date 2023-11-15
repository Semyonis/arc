using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.Views.Common.Models;

namespace Arc.Facades.Admins.Tables.Interfaces.Base;

public interface IExtendedTableFacade :
    IExtendedFunctionFacade
    <
        TableReadRequest,
        AdminIdentity
    >;