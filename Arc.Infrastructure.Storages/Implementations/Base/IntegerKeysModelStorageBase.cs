using Arc.Converters.Base.Interfaces;
using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Base;
using Arc.Infrastructure.Repositories.Read.Interfaces.Base;

namespace Arc.Infrastructure.Storages.Implementations.Base;

public abstract class IntegerKeysModelStorageBase
<
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
) : ModelStorageBase
<
    int,
    TModel,
    TEntity,
    TDictionary,
    TConverter
>(
    readRepository,
    dictionary,
    converter
)
    where TModel : class, IWithIdentifier
    where TEntity : class, IWithIdentifier
    where TDictionary : IModelDictionaryBase<int, TModel>
    where TConverter : IConverterBase<TEntity, TModel>
{
    protected override int GetModelKey(
        TModel model
    ) =>
        model.Id;
}