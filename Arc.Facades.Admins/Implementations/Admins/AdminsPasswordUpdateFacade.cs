using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminsPasswordUpdateFacade :
    IAdminsPasswordUpdateFacade
{
    public async Task<Response> Execute(
        AdminPasswordRequest request,
        AdminIdentity identity
    )
    {
        var email =
            await
                _adminReadRepository
                    .GetEmailById(
                        request.Id
                    );

        using var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        await
            _userPasswordManagerService
                .SetPassword(
                    email!,
                    request.NewPassword
                );

        await
            transaction
                .Commit();

        return
            _internalFacade
                .CreateOkResponse();
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly ITransactionManager
        _transactionManager;

    private readonly IUserPasswordManagerService
        _userPasswordManagerService;

    private readonly IAdminsReadRepository
        _adminReadRepository;

    public AdminsPasswordUpdateFacade(
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager,
        IUserPasswordManagerService
            userPasswordManagerService,
        IAdminsReadRepository
            adminReadRepository
    )
    {
        _internalFacade =
            internalFacade;

        _transactionManager =
            transactionManager;

        _userPasswordManagerService =
            userPasswordManagerService;

        _adminReadRepository =
            adminReadRepository;
    }

#endregion
}