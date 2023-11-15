using Arc.Converters.Base.Interfaces;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Common.Interfaces;

public interface IBaseDescriptionCreateRequestConverter<out TEntity> :
    IConverterBase
    <
        DescriptionCreateRequest,
        TEntity
    >;