using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Admins.Interfaces.Users;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Users;

public sealed class ConfirmUserEmailFacade(
        IUserManagerService
            userManagerService,
        IResponsesDomainFacade
            internalFacade,
        IUserTokenManagerService
            userTokenManagerService,
        IUsersReadRepository
            usersReadRepository,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    :
        IConfirmUserEmailFacade
{
    public async Task<Response> Execute(
        int userId,
        AdminIdentity identity
    )
    {
        var userEmail =
            await
                usersReadRepository
                    .GetEmailById(
                        userId
                    );

        if (userEmail.IsEmpty())
        {
            throw
                userNotFoundExceptionDescriptor.CreateException();
        }

        var user =
            await
                userManagerService
                    .FindByEmail(
                        userEmail
                    );

        if (user == default)
        {
            throw
                userNotFoundExceptionDescriptor.CreateException();
        }

        var token =
            await
                userTokenManagerService
                    .GetEmailChangeToken(
                        user,
                        userEmail
                    );

        var oldEmail =
            user.Email!;

        await
            userManagerService
                .ConfirmNewEmail(
                    token,
                    oldEmail,
                    oldEmail
                );

        return
            internalFacade
                .CreateOkResponse();
    }
}