using Arc.Facades.Admins.Tables.Interfaces.Base;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;

public interface IComplexPropertiesTableUpdateFacade :
    IExtendedTableUpdateFacade
    <
        ComplexPropertyTableUpdateRequest
    > { }