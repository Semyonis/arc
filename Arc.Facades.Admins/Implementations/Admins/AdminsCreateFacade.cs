using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminsCreateFacade :
    IAdminsCreateFacade
{
    public async Task<Response> Execute(
        AdminCreateRequest request,
        AdminIdentity identity
    )
    {
        using var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        var admin =
            new AdminCreateDomainFacadeArgs(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );

        var adminId =
            await
                _adminCreateDomainFacade
                    .Create(
                        admin
                    );

        await
            transaction
                .Commit();

        return
            _internalFacade
                .CreateOkResponse(
                    adminId
                );
    }

#region Constructor

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly IAdminCreateDomainFacade
        _adminCreateDomainFacade;

    private readonly ITransactionManager
        _transactionManager;

    public AdminsCreateFacade(
        IResponsesDomainFacade
            internalFacade,
        IAdminCreateDomainFacade
            adminCreateDomainFacade,
        ITransactionManager
            transactionManager
    )
    {
        _internalFacade =
            internalFacade;

        _adminCreateDomainFacade =
            adminCreateDomainFacade;

        _transactionManager =
            transactionManager;
    }

#endregion
}