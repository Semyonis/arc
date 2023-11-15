using Arc.Converters.Base.Interfaces;
using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Common.Interfaces;

public interface IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter :
    IConverterBase
    <
        FilterPropertyRequestRequest,
        FilterPropertyRequestModel
    >;