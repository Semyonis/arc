using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Arc.Converters.Base.Interfaces;
using Arc.Criteria.FilterParameters.Implementations.Base;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Base;
using Arc.Infrastructure.Repositories.Read.Interfaces.Base;
using Arc.Infrastructure.Storages.Interfaces.Base;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Infrastructure.Storages.Implementations.Base;

public abstract class ModelStorageBase
    <
        TKey,
        TModel,
        TEntity,
        TDictionary,
        TConverter
    >(
        IReadRepositoryBase<TEntity>
            readRepository,
        TDictionary
            dictionary,
        TConverter
            converter
    )
    :
        IModelStorageBase<TKey, TModel>
    where TKey : notnull
    where TModel : class, IWithIdentifier
    where TEntity : class, IWithIdentifier
    where TDictionary : IModelDictionaryBase<TKey, TModel>
    where TConverter : IConverterBase<TEntity, TModel>
{
    private readonly object _mutex =
        new();

    public async Task<TModel> Read(
        TKey key
    )
    {
        await
            Load();

        return
            _dictionary
                .Read(
                    key
                );
    }

    public async Task<IReadOnlyList<TModel>> Read()
    {
        await
            Load();

        return
            _dictionary
                .Read();
    }

    private async Task Load()
    {
        var isLoaded =
            _dictionary
                .IsLoaded();

        if (isLoaded)
        {
            return;
        }

        var include =
            GetInclude();

        var entities =
            await
                readRepository
                    .GetListByFiltersAsync(
                        GetFilters(),
                        include
                    );

        var dictionary =
            GetDictionary(
                entities
            );

        lock (_mutex)
        {
            var isLoadedInOtherThread =
                _dictionary
                    .IsLoaded();

            if (isLoadedInOtherThread)
            {
                return;
            }

            _dictionary
                .Set(
                    dictionary
                );
        }
    }

    private IDictionary<TKey, TModel> GetDictionary(
        IReadOnlyList<TEntity> entities
    )
    {
        var result =
            new Dictionary<TKey, TModel>();

        var models =
            _converter
                .Convert(
                    entities
                );

        foreach (var model in models)
        {
            var key =
                GetModelKey(
                    model
                );

            result
                .Add(
                    key,
                    model
                );
        }

        return
            result;
    }

    protected virtual Func
    <
        IQueryable<TEntity>,
        IIncludableQueryable<TEntity, object>
    >? GetInclude() =>
        default;

    protected virtual IReadOnlyList<FilterParameterBase<TEntity>> GetFilters() =>
        Array.Empty<FilterParameterBase<TEntity>>();

    protected abstract TKey GetModelKey(
        TModel key
    );

#region Constructor

    private readonly TConverter
        _converter = converter;

    private readonly TDictionary
        _dictionary = dictionary;

#endregion
}