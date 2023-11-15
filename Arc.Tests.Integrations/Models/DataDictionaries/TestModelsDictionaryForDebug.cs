using Arc.Infrastructure.Dictionaries.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Models.BusinessLogic.Models;
using Arc.Tests.Integrations.Models.DataDictionaries.Base;

namespace Arc.Tests.Integrations.Models.DataDictionaries;

public sealed class TestModelsDictionaryForDebug(
    IDictionariesManager dictionaryManager
) :
    ModelDictionaryBaseForDebug<int, GroupModel>(
        dictionaryManager
    ),
    IGroupModelsDictionary;