using Arc.Infrastructure.Common.Interfaces;

namespace Arc.Infrastructure.Dictionaries.Interfaces.Base;

public interface IIntegerKeysModelDictionaryBase<TModel> :
    IModelDictionaryBase<int, TModel>
    where TModel : class, IWithIdentifier { }