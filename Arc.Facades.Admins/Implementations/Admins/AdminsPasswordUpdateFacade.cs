using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminsPasswordUpdateFacade(
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager,
        IUserPasswordManagerService
            userPasswordManagerService,
        IAdminsReadRepository
            adminReadRepository
    )
    :
        IAdminsPasswordUpdateFacade
{
    public async Task<Response> Execute(
        AdminPasswordRequest request,
        AdminIdentity identity
    )
    {
        var email =
            await
                adminReadRepository
                    .GetEmailById(
                        request.Id
                    );

        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        await
            userPasswordManagerService
                .SetPassword(
                    email!,
                    request.NewPassword
                );

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse();
    }
}