using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class UsersUpdateFacade :
    IUsersUpdateFacade
{
    public async Task<Response> Execute(
        UserAdminEditRequest request,
        AdminIdentity identity
    )
    {
        using var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        var newUser =
            new UserUpdateDomainFacadeArgs(
                request.Id,
                request.FirstName,
                request.LastName
            );

        await
            _userUpdateDomainFacade
                .Update(
                    newUser
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

    private readonly IUserUpdateDomainFacade
        _userUpdateDomainFacade;

    private readonly IResponsesDomainFacade
        _internalFacade;

    public UsersUpdateFacade(
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager,
        IUserUpdateDomainFacade
            userUpdateDomainFacade
    )
    {
        _internalFacade =
            internalFacade;

        _transactionManager =
            transactionManager;

        _userUpdateDomainFacade =
            userUpdateDomainFacade;
    }

#endregion
}