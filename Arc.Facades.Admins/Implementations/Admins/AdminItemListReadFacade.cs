using Arc.Converters.Views.Common.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminItemListReadFacade :
    IAdminItemListReadFacade
{
    public async Task<Response> Execute(
        AdminIdentity identity
    )
    {
        var admins =
            await
                _adminsReadRepository
                    .GetAll();

        var responses =
            _adminToListItemResponseConverter
                .Convert(
                    admins
                );

        return
            _internalFacade
                .CreateOkResponse(
                    responses
                );
    }

#region Constructor

    private readonly IAdminToListItemResponseConverter
        _adminToListItemResponseConverter;

    private readonly IAdminsReadRepository
        _adminsReadRepository;

    private readonly IResponsesDomainFacade
        _internalFacade;

    public AdminItemListReadFacade(
        IAdminToListItemResponseConverter
            adminToListItemResponseConverter,
        IAdminsReadRepository
            adminsReadRepository,
        IResponsesDomainFacade
            internalFacade
    )
    {
        _adminToListItemResponseConverter =
            adminToListItemResponseConverter;

        _adminsReadRepository =
            adminsReadRepository;

        _internalFacade =
            internalFacade;
    }

#endregion
}