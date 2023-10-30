using Arc.Facades.Admins.Interfaces.Emergency;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Models;

namespace Arc.Facades.Admins.Implementations.Emergency;

public sealed class OperatingModeControlUpdateFacade :
    IOperatingModeControlUpdateFacade
{
    public async Task<Response> Execute(
        ServiceModeAdminEditRequest request,
        AdminIdentity identity
    )
    {
        using var transaction =
            await
                _transactionManager
                    .BeginTransaction();

        var requestModel =
            new ModeControlDomainFacadeArgs(
                request.Mode,
                identity.Id
            );

        await
            _modeControlDomainFacade
                .SetMode(
                    requestModel
                );

        await
            transaction
                .Commit();

        return
            _internalFacade
                .CreateOkResponse();
    }

#region Constructor

    private readonly IModeControlDomainFacade
        _modeControlDomainFacade;

    private readonly IResponsesDomainFacade
        _internalFacade;

    private readonly ITransactionManager
        _transactionManager;

    public OperatingModeControlUpdateFacade(
        IModeControlDomainFacade
            modeControlDomainFacade,
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager
    )
    {
        _modeControlDomainFacade =
            modeControlDomainFacade;

        _internalFacade =
            internalFacade;

        _transactionManager =
            transactionManager;
    }

#endregion
}