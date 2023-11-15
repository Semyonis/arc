using Arc.Facades.Anonymous.Interfaces.Registration;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Anonymous.Models;

namespace Arc.Facades.Anonymous.Implementations.Registration;

public sealed class RegistrationFacade(
    IResponsesDomainFacade
        internalFacade,
    IUserCreateDomainFacade
        userCreateDomainFacade,
    ITransactionManager
        transactionManager
) : IRegistrationFacade
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