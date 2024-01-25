using Arc.Facades.Base.Interfaces.Executors;

namespace Arc.Facades.Admins.Tables.Interfaces.Base;

public interface IExtendedTableUpdateFacade
<
    in TUpdateRequest
> :
    IExtendedFunctionFacade
    <
        TUpdateRequest
    >;