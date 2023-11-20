using Arc.Infrastructure.Cache.Interfaces.Base;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

namespace Arc.Infrastructure.Dictionaries.Implementations.Base;

public abstract class ModelDictionaryBaseIntegerKeys<TModel>(
    IDictionariesManager
        dictionaryManager,
    IDataCache
        dataCache
) : ModelDictionaryBase<int, TModel>(
    dictionaryManager,
    dataCache
)
    where TModel : class, IWithIdentifier;