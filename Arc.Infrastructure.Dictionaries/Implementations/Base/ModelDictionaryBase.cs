using Arc.Infrastructure.Cache.Interfaces.Base;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Base;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

namespace Arc.Infrastructure.Dictionaries.Implementations.Base;

public abstract class ModelDictionaryBase
<
    TKey,
    TModel
> :
    IModelDictionaryBase
    <
        TKey,
        TModel
    >
    where TModel : class, IWithIdentifier
{
    private readonly IDataCache
        _dataCache;

    private readonly string _keyKeyList =
        $"{typeof(TModel)}_key_list";

    private readonly string _keyValueList =
        $"{typeof(TModel)}_value_list";

    protected ModelDictionaryBase(
        IDictionariesManager
            dictionaryManager,
        IDataCache
            dataCache
    )
    {
        _dataCache =
            dataCache;

        dictionaryManager
            .Register(
                this
            );
    }

    public void Set(
        IDictionary<TKey, TModel> dictionaryItems
    )
    {
        var models =
            dictionaryItems
                .Values;

        _dataCache
            .Set(
                _keyValueList,
                models
            );

        foreach (var keyValuePair in dictionaryItems)
        {
            (
                var entityKey,
                var entityValue
            ) = keyValuePair;

            var key =
                GetEntityKey(
                    entityKey
                );

            _dataCache
                .Set(
                    key,
                    entityValue
                );
        }

        var keys =
            dictionaryItems.Keys;

        _dataCache
            .Set(
                _keyKeyList,
                keys
            );
    }

    public TModel Read(
        TKey key
    )
    {
        var entityKey =
            GetEntityKey(
                key
            );

        return
            _dataCache
                .Read<TModel>(
                    entityKey
                )!;
    }

    public IReadOnlyList<TModel> Read() =>
        _dataCache
            .Read<IReadOnlyList<TModel>>(
                _keyValueList
            )!;

    protected abstract IReadOnlyList<Type> GetDependencies();

    private string GetEntityKey(
        TKey key
    ) =>
        $"{_keyValueList}_{key}";

#region IDictionaryItem

    bool IDictionaryBase.IsDependentFrom(
        Type dependencyType
    )
    {
        var dependencies =
            GetDependencies();

        return dependencies
            .Contains(
                dependencyType
            );
    }

    bool IDictionaryBase.IsLoaded()
    {
        var keys =
            _dataCache
                .Read<IReadOnlyList<TKey>>(
                    _keyKeyList
                );

        return
            keys
                .IsNotEmpty();
    }

    void IDictionaryBase.Clear()
    {
        var keys =
            _dataCache
                .Read<IReadOnlyList<TKey>>(
                    _keyKeyList
                )!;

        foreach (var key in keys)
        {
            var entityKey =
                GetEntityKey(
                    key
                );

            _dataCache
                .Delete(
                    entityKey
                );
        }

        _dataCache
            .Delete(
                _keyValueList
            );

        _dataCache
            .Delete(
                _keyKeyList
            );
    }

#endregion
}