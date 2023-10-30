using Arc.Infrastructure.Common.Interfaces;

namespace Arc.Infrastructure.Dictionaries.Interfaces.Base;

public interface IModelDictionaryBase<TKey, TModel> :
    IDictionaryBase
    where TModel : class, IWithIdentifier
{
    void Set(
        IDictionary<TKey, TModel> dictionaryItems
    );

    TModel Read(
        TKey key
    );

    IReadOnlyList<TModel> Read();
}