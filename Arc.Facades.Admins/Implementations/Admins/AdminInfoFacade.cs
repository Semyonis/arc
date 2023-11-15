using Arc.Converters.Views.Admins.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminInfoFacade(
    IAdminsReadRepository
        adminsReadRepository,
    IAdminToAdminInfoResponseConverter
        adminToAdminInfoResponseConverter,
    IResponsesDomainFacade
        internalFacade
) : IAdminInfoFacade
{
    public async Task<Response> Execute(
        AdminIdentity identity
    )
    {
        var adminInfo =
            await
                adminsReadRepository
                    .GetById(
                        identity.Id
                    );

        var result =
            adminToAdminInfoResponseConverter
                .Convert(
                    adminInfo!
                );

        return
            internalFacade
                .CreateOkResponse(
                    result
                );
    }
}