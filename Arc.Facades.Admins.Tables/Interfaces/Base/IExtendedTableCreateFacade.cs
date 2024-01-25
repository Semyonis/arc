using Arc.Facades.Base.Interfaces.Executors;

namespace Arc.Facades.Admins.Tables.Interfaces.Base;

public interface IExtendedTableCreateFacade
<
    in TCreateRequest
> :
    IExtendedFunctionFacade
    <
        TCreateRequest
    >;