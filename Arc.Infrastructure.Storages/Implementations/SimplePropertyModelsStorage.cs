using Arc.Converters.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Storages.Implementations;

public sealed class SimplePropertyModelsStorage :
    IntegerKeysModelStorageBase
    <
        SimplePropertyModel,
        SimpleProperty,
        ISimplePropertyModelsDictionary,
        ISimplePropertyToSimplePropertyModelConverter
    >,
    ISimplePropertyModelsStorage
{
    public SimplePropertyModelsStorage(
        ISimplePropertiesReadRepository
            readRepository,
        ISimplePropertyModelsDictionary
            dictionary,
        ISimplePropertyToSimplePropertyModelConverter
            converter
    ) : base(
        readRepository,
        dictionary,
        converter
    ) { }
}