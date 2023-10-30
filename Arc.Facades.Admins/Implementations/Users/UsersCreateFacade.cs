using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class UsersCreateFacade :
    IUsersCreateFacade
{
    public Task Validate(
        AdminIdentity identity
    ) =>
        Task.CompletedTask;

    public async Task<Response> Execute(
        CreateUserAdminRequest model
    )
    {
        var internalCreateUserFacadeArgs =
            new CreateUserDomainFacadeArgs(
                model.FirstName,
                model.LastName,
                model.Email,
                model.Password
            );

        var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        await
            _userCreateDomainFacade
                .Create(
                    internalCreateUserFacadeArgs
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

    private readonly IUserCreateDomainFacade
        _userCreateDomainFacade;

    private readonly ITransactionManager
        _transactionManager;

    public UsersCreateFacade(
        IResponsesDomainFacade
            internalFacade,
        IUserCreateDomainFacade
            userCreateDomainFacade,
        ITransactionManager
            transactionManager
    )
    {
        _internalFacade =
            internalFacade;

        _userCreateDomainFacade =
            userCreateDomainFacade;

        _transactionManager =
            transactionManager;
    }

#endregion
}