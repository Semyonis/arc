using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminsUpdateFacade :
    IAdminsUpdateFacade
{
    public async Task<Response> Execute(
        AdminUpdateRequest request
    )
    {
        using var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        var admin =
            new AdminUpdateDomainFacadeArgs(
                request.Id,
                request.FirstName,
                request.LastName
            );

        await
            _adminUpdateDomainFacade
                .Update(
                    admin
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

    private readonly IAdminUpdateDomainFacade
        _adminUpdateDomainFacade;

    public AdminsUpdateFacade(
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager,
        IAdminUpdateDomainFacade
            adminUpdateDomainFacade
    )
    {
        _internalFacade =
            internalFacade;

        _transactionManager =
            transactionManager;

        _adminUpdateDomainFacade =
            adminUpdateDomainFacade;
    }

#endregion
}