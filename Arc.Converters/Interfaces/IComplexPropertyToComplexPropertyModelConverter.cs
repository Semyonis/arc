using Arc.Converters.Base.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Converters.Interfaces;

public interface IComplexPropertyToComplexPropertyModelConverter :
    IConverterBase
    <
        ComplexProperty,
        ComplexPropertyModel
    > { }