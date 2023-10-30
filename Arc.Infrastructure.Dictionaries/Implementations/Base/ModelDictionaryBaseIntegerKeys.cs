using Arc.Dependencies.Cache.Interfaces.Base;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

namespace Arc.Infrastructure.Dictionaries.Implementations.Base;

public abstract class ModelDictionaryBaseIntegerKeys<TModel> :
    ModelDictionaryBase<int, TModel>
    where TModel : class, IWithIdentifier
{
    protected ModelDictionaryBaseIntegerKeys(
        IDictionariesManager
            dictionaryManager,
        IDataCache
            dataCache
    ) : base(
        dictionaryManager,
        dataCache
    ) { }
}