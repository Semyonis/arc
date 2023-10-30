using Arc.Converters.Base.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Common.Models;

namespace Arc.Converters.Views.Common.Interfaces;

public interface IBaseDescriptionResponseConverter<in TEntity> :
    IConverterBase
    <
        TEntity,
        DescriptionResponse
    >
    where TEntity : BaseDescription { }