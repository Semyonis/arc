using Arc.Converters.Views.Admins.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminInfoFacade :
    IAdminInfoFacade
{
    public async Task<Response> Execute(
        AdminIdentity identity
    )
    {
        var adminInfo =
            await
                _adminsReadRepository
                    .GetById(
                        identity.Id
                    );

        var result =
            _adminToAdminInfoResponseConverter
                .Convert(
                    adminInfo!
                );

        return
            _internalFacade
                .CreateOkResponse(
                    result
                );
    }

#region Constructor

    private readonly IAdminsReadRepository
        _adminsReadRepository;

    private readonly IAdminToAdminInfoResponseConverter
        _adminToAdminInfoResponseConverter;

    private readonly IResponsesDomainFacade
        _internalFacade;

    public AdminInfoFacade(
        IAdminsReadRepository
            adminsReadRepository,
        IAdminToAdminInfoResponseConverter
            adminToAdminInfoResponseConverter,
        IResponsesDomainFacade
            internalFacade
    )
    {
        _adminsReadRepository =
            adminsReadRepository;

        _adminToAdminInfoResponseConverter =
            adminToAdminInfoResponseConverter;

        _internalFacade =
            internalFacade;
    }

#endregion
}