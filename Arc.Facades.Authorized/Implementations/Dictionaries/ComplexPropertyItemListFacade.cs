using Arc.Converters.Interfaces;
using Arc.Facades.Authorized.Interfaces.Dictionaries;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Storages.Interfaces;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Authorized.Implementations.Dictionaries;

public sealed class ComplexPropertyItemListFacade :
    IComplexPropertyItemListFacade
{
    public async Task<Response> Execute()
    {
        var entities =
            await
                _complexPropertyModelsStorage.Read();

        var results =
            _complexPropertyModelToListItemResponseConverter
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

    private readonly IComplexPropertyModelsStorage
        _complexPropertyModelsStorage;

    private readonly IComplexPropertyModelToListItemResponseConverter
        _complexPropertyModelToListItemResponseConverter;

    public ComplexPropertyItemListFacade(
        IResponsesDomainFacade
            internalFacade,
        IComplexPropertyModelsStorage
            complexPropertyModelsStorage,
        IComplexPropertyModelToListItemResponseConverter
            complexPropertyModelToListItemResponseConverter
    )
    {
        _internalFacade =
            internalFacade;

        _complexPropertyModelsStorage =
            complexPropertyModelsStorage;

        _complexPropertyModelToListItemResponseConverter =
            complexPropertyModelToListItemResponseConverter;
    }

#endregion
}