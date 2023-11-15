using Arc.Facades.Admins.Interfaces.Admins;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Admins;

public sealed class AdminsUpdateFacade(
    IResponsesDomainFacade
        internalFacade,
    ITransactionManager
        transactionManager,
    IAdminUpdateDomainFacade
        adminUpdateDomainFacade
) : IAdminsUpdateFacade
{
    public async Task<Response> Execute(
        AdminUpdateRequest request
    )
    {
        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        var admin =
            new AdminUpdateDomainFacadeArgs(
                request.Id,
                request.FirstName,
                request.LastName
            );

        await
            adminUpdateDomainFacade
                .Update(
                    admin
                );

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse();
    }
}