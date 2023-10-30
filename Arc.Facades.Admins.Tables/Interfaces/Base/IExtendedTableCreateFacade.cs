using Arc.Facades.Base.Interfaces.Executors;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Facades.Admins.Tables.Interfaces.Base;

public interface IExtendedTableCreateFacade
<
    in TCreateRequest
> :
    IExtendedFunctionFacade
    <
        TCreateRequest,
        AdminIdentity
    > { }