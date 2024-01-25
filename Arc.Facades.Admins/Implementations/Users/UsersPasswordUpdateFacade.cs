using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class UsersPasswordUpdateFacade(
    IResponsesDomainFacade
        internalFacade,
    ITransactionManager
        transactionManager,
    IUserPasswordUpdateDomainFacade
        userPasswordUpdateDomainFacade
) : IUsersPasswordUpdateFacade
{
    public async Task<Response> Execute(
        ChangePasswordAdminRequest request,
        ArcIdentity identity
    )
    {
        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        var model =
            new UserPasswordUpdateDomainFacadeArgs(
                request.Email,
                request.Password
            );

        await
            userPasswordUpdateDomainFacade
                .ChangePassword(
                    model
                );

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse();
    }
}