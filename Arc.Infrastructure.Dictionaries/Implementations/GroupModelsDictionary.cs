using Arc.Infrastructure.Cache.Interfaces.Base;
using Arc.Infrastructure.Dictionaries.Implementations.Base;
using Arc.Infrastructure.Dictionaries.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Models.BusinessLogic.Models;
using Arc.Database.Entities.Models;

namespace Arc.Infrastructure.Dictionaries.Implementations;

public sealed class GroupModelsDictionary(
    IDictionariesManager dictionaryManager,
    IDataCache dataCache
) : ModelDictionaryBaseIntegerKeys<GroupModel>(
        dictionaryManager,
        dataCache
    ),
    IGroupModelsDictionary
{
    protected override IReadOnlyList<Type> GetDependencies() =>
        new[]
        {
            typeof(Group),
            typeof(GroupDescription),
        };
}