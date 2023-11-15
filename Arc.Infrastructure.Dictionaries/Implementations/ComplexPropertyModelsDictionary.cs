using Arc.Dependencies.Cache.Interfaces.Base;
using Arc.Infrastructure.Dictionaries.Implementations.Base;
using Arc.Infrastructure.Dictionaries.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Dictionaries.Implementations;

public sealed class ComplexPropertyModelsDictionary(
        IDictionariesManager dictionaryManager,
        IDataCache dataCache
    )
    :
        ModelDictionaryBaseIntegerKeys<ComplexPropertyModel>(
            dictionaryManager,
            dataCache
        ),
        IComplexPropertyModelsDictionary
{
    protected override IReadOnlyList<Type> GetDependencies() =>
        new[]
        {
            typeof(Group),
            typeof(ComplexProperty),
            typeof(ComplexPropertyDescription),
        };
}