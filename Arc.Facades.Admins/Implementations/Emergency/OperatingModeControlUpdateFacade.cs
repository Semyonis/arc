using Arc.Facades.Admins.Interfaces.Emergency;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Emergency;

public sealed class OperatingModeControlUpdateFacade(
    IModeControlDomainFacade
        modeControlDomainFacade,
    IResponsesDomainFacade
        internalFacade,
    ITransactionManager
        transactionManager
) : IOperatingModeControlUpdateFacade
{
    public async Task<Response> Execute(
        ServiceModeAdminEditRequest request,
        AdminIdentity identity
    )
    {
        using var transaction =
            await
                transactionManager
                    .BeginTransaction();

        var requestModel =
            new ModeControlDomainFacadeArgs(
                request.Mode,
                identity.Id
            );

        await
            modeControlDomainFacade
                .SetMode(
                    requestModel
                );

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse();
    }
}