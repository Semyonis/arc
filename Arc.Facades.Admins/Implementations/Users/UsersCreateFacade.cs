using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class UsersCreateFacade(
    IResponsesDomainFacade
        internalFacade,
    IUserCreateDomainFacade
        userCreateDomainFacade,
    ITransactionManager
        transactionManager
) : IUsersCreateFacade
{
    public Task Validate(
        ArcIdentity identity
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
                transactionManager
                    .BeginTransaction();

        await
            userCreateDomainFacade
                .Create(
                    internalCreateUserFacadeArgs
                );

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse();
    }
}