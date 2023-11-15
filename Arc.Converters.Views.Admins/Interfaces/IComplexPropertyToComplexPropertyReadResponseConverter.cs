using Arc.Converters.Base.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Converters.Views.Admins.Interfaces;

public interface IComplexPropertyToComplexPropertyReadResponseConverter :
    IConverterBase
    <
        ComplexProperty,
        ComplexPropertyReadResponse
    >;