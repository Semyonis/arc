using Arc.Converters.Base.Interfaces;

namespace Arc.Converters.Views.Common.Interfaces;

public interface IStringToDescriptionEntityConverter<out TEntity> :
    IConverterBase
    <
        string,
        TEntity
    >;