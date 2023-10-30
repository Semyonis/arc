using System.Collections.Generic;
using System.Threading.Tasks;

namespace Arc.Infrastructure.Storages.Interfaces.Base;

public interface IModelStorageBase<in TKey, TModel>
{
    Task<TModel> Read(
        TKey key
    );

    Task<IReadOnlyList<TModel>> Read();
}