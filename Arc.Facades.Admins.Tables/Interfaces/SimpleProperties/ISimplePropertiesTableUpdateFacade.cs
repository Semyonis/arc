using Arc.Facades.Admins.Tables.Interfaces.Base;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;

public interface ISimplePropertiesTableUpdateFacade :
    IExtendedTableUpdateFacade
    <
        SimplePropertyTableUpdateRequest
    >;