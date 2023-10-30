using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class UsersDeleteFacade :
    IUsersDeleteFacade
{
    public async Task<Response> Execute(
        DeleteEntityAdminRequest request,
        AdminIdentity identity
    )
    {
        using var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        await
            _userDeleteDomainFacade
                .Delete(
                    request.Id
                );

        await
            transaction
                .Commit();

        return
            _internalFacade
                .CreateOkResponse();
    }

#region Constructor

    private readonly ITransactionManager
        _transactionManager;

    private readonly IUserDeleteDomainFacade
        _userDeleteDomainFacade;

    private readonly IResponsesDomainFacade
        _internalFacade;

    public UsersDeleteFacade(
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager,
        IUserDeleteDomainFacade
            userDeleteDomainFacade
    )
    {
        _internalFacade =
            internalFacade;

        _transactionManager =
            transactionManager;

        _userDeleteDomainFacade =
            userDeleteDomainFacade;
    }

#endregion
}