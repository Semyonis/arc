using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class UsersUpdateFacade(
    IResponsesDomainFacade
        internalFacade,
    ITransactionManager
        transactionManager,
    IUserUpdateDomainFacade
        userUpdateDomainFacade
) : IUsersUpdateFacade
{
    public async Task<Response> Execute(
        UserAdminEditRequest request,
        ArcIdentity identity
    )
    {
        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        var newUser =
            new UserUpdateDomainFacadeArgs(
                request.Id,
                request.FirstName,
                request.LastName
            );

        await
            userUpdateDomainFacade
                .Update(
                    newUser
                );

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse();
    }
}