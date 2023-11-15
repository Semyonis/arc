using Arc.Converters.Views.Common.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminItemListReadFacade(
        IAdminToListItemResponseConverter
            adminToListItemResponseConverter,
        IAdminsReadRepository
            adminsReadRepository,
        IResponsesDomainFacade
            internalFacade
    )
    :
        IAdminItemListReadFacade
{
    public async Task<Response> Execute(
        AdminIdentity identity
    )
    {
        var admins =
            await
                adminsReadRepository
                    .GetAll();

        var responses =
            adminToListItemResponseConverter
                .Convert(
                    admins
                );

        return
            internalFacade
                .CreateOkResponse(
                    responses
                );
    }
}