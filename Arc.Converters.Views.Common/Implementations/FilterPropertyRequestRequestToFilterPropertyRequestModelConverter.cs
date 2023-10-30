using Arc.Models.BusinessLogic.Models.FilterProperties;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Common.Implementations;

public class FilterPropertyRequestRequestToFilterPropertyRequestModelConverter :
    ConverterBase
    <
        FilterPropertyRequestRequest,
        FilterPropertyRequestModel
    >,
    IFilterPropertyRequestRequestToFilterPropertyRequestModelConverter
{
    public override FilterPropertyRequestModel Convert(
        FilterPropertyRequestRequest entity
    ) =>
        new(
            entity.Property,
            entity.Operation,
            entity.Value
        );
}