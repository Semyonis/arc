using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class UserDeleteDomainFacade(
        IUsersReadRepository
            usersReadRepository,
        IDeleteRepository
            usersRepository,
        IUserManagerService
            userManagerService,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    :
        IUserDeleteDomainFacade
{
    public async Task Delete(
        int userId
    )
    {
        var user =
            await
                usersReadRepository
                    .GetById(
                        userId,
                        default,
                        false
                    );

        if (user == default)
        {
            throw
                userNotFoundExceptionDescriptor.CreateException();
        }

        await
            usersRepository
                .DeleteAsync(
                    user
                );

        var identityUser =
            await
                userManagerService
                    .FindByEmail(
                        user.Email
                    );

        if (identityUser != default)
        {
            await
                userManagerService
                    .Delete(
                        identityUser
                    );
        }
    }

#region Constrctor

#endregion
}