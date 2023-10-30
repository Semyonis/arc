using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class UsersPasswordUpdateFacade :
    IUsersPasswordUpdateFacade
{
    public async Task<Response> Execute(
        ChangePasswordAdminRequest request,
        AdminIdentity identity
    )
    {
        using var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        var model =
            new UserPasswordUpdateDomainFacadeArgs(
                request.Email,
                request.Password
            );

        await
            _userPasswordUpdateDomainFacade
                .ChangePassword(
                    model
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

    private readonly IUserPasswordUpdateDomainFacade
        _userPasswordUpdateDomainFacade;

    private readonly IResponsesDomainFacade
        _internalFacade;

    public UsersPasswordUpdateFacade(
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager,
        IUserPasswordUpdateDomainFacade
            userPasswordUpdateDomainFacade
    )
    {
        _internalFacade =
            internalFacade;

        _transactionManager =
            transactionManager;

        _userPasswordUpdateDomainFacade =
            userPasswordUpdateDomainFacade;
    }

#endregion
}