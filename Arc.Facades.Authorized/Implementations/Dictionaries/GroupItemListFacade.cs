using Arc.Converters.Interfaces;
using Arc.Facades.Authorized.Interfaces.Dictionaries;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Storages.Interfaces;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Authorized.Implementations.Dictionaries;

public sealed class GroupItemListFacade(
        IResponsesDomainFacade
            internalFacade,
        IGroupModelsStorage
            complexPropertyModelsStorage,
        IGroupModelToListItemResponseConverter
            groupModelToListItemResponseConverter
    )
    :
        IGroupItemListFacade
{
    public async Task<Response> Execute()
    {
        var entities =
            await
                complexPropertyModelsStorage.Read();

        var results =
            groupModelToListItemResponseConverter
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