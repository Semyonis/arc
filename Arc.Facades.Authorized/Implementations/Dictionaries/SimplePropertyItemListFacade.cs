using Arc.Converters.Interfaces;
using Arc.Facades.Authorized.Interfaces.Dictionaries;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Storages.Interfaces;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Authorized.Implementations.Dictionaries;

public sealed class SimplePropertyItemListFacade(
        IResponsesDomainFacade
            internalFacade,
        ISimplePropertyModelsStorage
            breedModelsStorage,
        ISimplePropertyModelToListItemResponseConverter
            simplePropertyModelToListItemResponseConverter
    )
    :
        ISimplePropertyItemListFacade
{
    public async Task<Response> Execute()
    {
        var entities =
            await
                breedModelsStorage.Read();

        var results =
            simplePropertyModelToListItemResponseConverter
                .Convert(
                    entities
                );

        return
            internalFacade
                .CreateOkResponse(
                    results
                );
    }
}