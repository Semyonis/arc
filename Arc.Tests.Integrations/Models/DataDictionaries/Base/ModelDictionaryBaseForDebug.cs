using System;
using System.Collections.Generic;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Base;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;

namespace Arc.Tests.Integrations.Models.DataDictionaries.Base;

public abstract class ModelDictionaryBaseForDebug<TKey, TModel> :
    IModelDictionaryBase<TKey, TModel>
    where TKey : notnull
    where TModel : class, IWithIdentifier
{
    private IDictionary<TKey, TModel> _dictionary =
        new Dictionary<TKey, TModel>();

    protected ModelDictionaryBaseForDebug(
        IDictionariesManager dictionaryManager
    ) =>
        dictionaryManager
            .Register(
                this
            );

    public bool IsLoaded() =>
        _dictionary.IsNotEmpty();

    public void Clear() =>
        _dictionary =
            new Dictionary<TKey, TModel>();

    public bool IsDependentFrom(
        Type dependencyType
    ) =>
        false;

    public void Set(
        IDictionary<TKey, TModel> dictionaryItems
    ) =>
        _dictionary =
            dictionaryItems;

    public TModel Read(
        TKey key
    )
    {
        var dictionary =
            _dictionary;

        var isSuccess =
            dictionary
                .TryGetValue(
                    key,
                    out var model
                );

        if (isSuccess)
        {
            return model!;
        }

        //todo : check this result  
        return default!;
    }

    public IReadOnlyList<TModel> Read() =>
        _dictionary
            .Values
            .ToList();
}