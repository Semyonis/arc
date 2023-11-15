using Arc.Facades.Domain.Interface;
using Arc.Facades.Users.Interfaces;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Users.Models;

namespace Arc.Facades.Users.Implementations;

public sealed class ProfileUpdateFacade(
        IResponsesDomainFacade
            internalFacade,
        IUsersReadRepository
            usersReadRepository,
        ITransactionManager
            transactionManager,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor,
        IAccessDeniedExceptionDescriptor
            accessDeniedExceptionDescriptor
    )
    :
        IProfileUpdateFacade
{
    public async Task<Response> Execute(
        UserRequest userProfile,
        UserIdentity identity
    )
    {
        if (userProfile.Id != identity.Id)
        {
            throw
                accessDeniedExceptionDescriptor.CreateException();
        }

        using var transaction =
            await
                transactionManager.BeginTransaction();

        var user =
            await
                usersReadRepository
                    .GetById(
                        userProfile.Id,
                        asNoTracking: false
                    );

        if (user == default)
        {
            throw
                userNotFoundExceptionDescriptor.CreateException();
        }

        user.FirstName =
            userProfile.FirstName;

        user.LastName =
            userProfile.LastName;

        await
            transaction
                .Commit();

        return
            internalFacade
                .CreateOkResponse();
    }
}