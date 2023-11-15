using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Facades.Admins.Tables.Interfaces.Base;

public interface IExtendedTableDeleteFacade :
    IExtendedFunctionFacade
    <
        IReadOnlyList<int>,
        AdminIdentity
    >;