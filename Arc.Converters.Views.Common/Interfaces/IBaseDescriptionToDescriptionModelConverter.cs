using Arc.Converters.Base.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Database.Entities.Models;

namespace Arc.Converters.Views.Common.Interfaces;

public interface IBaseDescriptionToDescriptionModelConverter :
    IConverterBase
    <
        BaseDescription,
        DescriptionModel
    >;