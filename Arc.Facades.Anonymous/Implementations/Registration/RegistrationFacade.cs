using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Registration;

public sealed class RegistrationFacade :
    IRegistrationFacade
{
    public async Task<Response> Execute(
        CreateUserRequest model
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

    public RegistrationFacade(
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