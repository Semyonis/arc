using Arc.Converters.Base.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Common.Interfaces;

public interface IBaseDescriptionResponseConverter<in TEntity> :
    IConverterBase
    <
        TEntity,
        DescriptionResponse
    >
    where TEntity : BaseDescription;