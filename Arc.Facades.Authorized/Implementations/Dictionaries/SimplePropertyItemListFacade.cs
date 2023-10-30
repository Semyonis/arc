using Arc.Converters.Interfaces;
using Arc.Facades.Authorized.Interfaces.Dictionaries;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Storages.Interfaces;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Authorized.Implementations.Dictionaries;

public sealed class SimplePropertyItemListFacade :
    ISimplePropertyItemListFacade
{
    public async Task<Response> Execute()
    {
        var entities =
            await
                _breedModelsStorage.Read();

        var results =
            _simplePropertyModelToListItemResponseConverter
                .Convert(
                    entities
                );

        return
            _internalFacade
                .CreateOkResponse(
                    results
                );
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly ISimplePropertyModelsStorage
        _breedModelsStorage;

    private readonly ISimplePropertyModelToListItemResponseConverter
        _simplePropertyModelToListItemResponseConverter;

    public SimplePropertyItemListFacade(
        IResponsesDomainFacade
            internalFacade,
        ISimplePropertyModelsStorage
            breedModelsStorage,
        ISimplePropertyModelToListItemResponseConverter
            simplePropertyModelToListItemResponseConverter
    )
    {
        _internalFacade =
            internalFacade;

        _breedModelsStorage =
            breedModelsStorage;

        _simplePropertyModelToListItemResponseConverter =
            simplePropertyModelToListItemResponseConverter;
    }

#endregion
}