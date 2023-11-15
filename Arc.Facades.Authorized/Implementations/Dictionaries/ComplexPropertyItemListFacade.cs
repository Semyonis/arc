using Arc.Converters.Interfaces;
using Arc.Facades.Authorized.Interfaces.Dictionaries;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Storages.Interfaces;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Authorized.Implementations.Dictionaries;

public sealed class ComplexPropertyItemListFacade(
        IResponsesDomainFacade
            internalFacade,
        IComplexPropertyModelsStorage
            complexPropertyModelsStorage,
        IComplexPropertyModelToListItemResponseConverter
            complexPropertyModelToListItemResponseConverter
    )
    :
        IComplexPropertyItemListFacade
{
    public async Task<Response> Execute()
    {
        var entities =
            await
                complexPropertyModelsStorage.Read();

        var results =
            complexPropertyModelToListItemResponseConverter
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