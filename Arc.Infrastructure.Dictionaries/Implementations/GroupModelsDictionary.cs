using Arc.Dependencies.Cache.Interfaces.Base;
using Arc.Infrastructure.Dictionaries.Implementations.Base;
using Arc.Infrastructure.Dictionaries.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Dictionaries.Implementations;

public sealed class GroupModelsDictionary :
    ModelDictionaryBaseIntegerKeys<GroupModel>,
    IGroupModelsDictionary
{
    public GroupModelsDictionary(
        IDictionariesManager dictionaryManager,
        IDataCache dataCache
    ) : base(
        dictionaryManager,
        dataCache
    ) { }

    protected override IReadOnlyList<Type> GetDependencies() =>
        new[]
        {
            typeof(Group),
            typeof(GroupDescription),
        };
}