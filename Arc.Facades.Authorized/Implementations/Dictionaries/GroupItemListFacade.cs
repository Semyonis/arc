using Arc.Converters.Interfaces;
using Arc.Facades.Authorized.Interfaces.Dictionaries;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Storages.Interfaces;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Authorized.Implementations.Dictionaries;

public sealed class GroupItemListFacade :
    IGroupItemListFacade
{
    public async Task<Response> Execute()
    {
        var entities =
            await
                _complexPropertyModelsStorage.Read();

        var results =
            _groupModelToListItemResponseConverter
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

    private readonly IGroupModelsStorage
        _complexPropertyModelsStorage;

    private readonly IGroupModelToListItemResponseConverter
        _groupModelToListItemResponseConverter;

    public GroupItemListFacade(
        IResponsesDomainFacade
            internalFacade,
        IGroupModelsStorage
            complexPropertyModelsStorage,
        IGroupModelToListItemResponseConverter
            groupModelToListItemResponseConverter
    )
    {
        _internalFacade =
            internalFacade;

        _complexPropertyModelsStorage =
            complexPropertyModelsStorage;

        _groupModelToListItemResponseConverter =
            groupModelToListItemResponseConverter;
    }

#endregion
}