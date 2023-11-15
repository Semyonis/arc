using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class UsersDeleteFacade(
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager,
        IUserDeleteDomainFacade
            userDeleteDomainFacade
    )
    :
        IUsersDeleteFacade
{
    public async Task<Response> Execute(
        DeleteEntityAdminRequest request,
        AdminIdentity identity
    )
    {
        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        await
            userDeleteDomainFacade
                .Delete(
                    request.Id
                );

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse();
    }
}