using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class UserDeleteDomainFacade :
    IUserDeleteDomainFacade
{
    public async Task Delete(
        int userId
    )
    {
        var user =
            await
                _usersReadRepository
                    .GetById(
                        userId,
                        default,
                        false
                    );

        if (user == default)
        {
            throw
                _userNotFoundExceptionDescriptor.CreateException();
        }

        await
            _usersRepository
                .DeleteAsync(
                    user
                );

        var identityUser =
            await
                _userManagerService
                    .FindByEmail(
                        user.Email
                    );

        if (identityUser != default)
        {
            await
                _userManagerService
                    .Delete(
                        identityUser
                    );
        }
    }

#region Constrctor

    private readonly IUsersReadRepository
        _usersReadRepository;

    private readonly IDeleteRepository
        _usersRepository;

    private readonly IUserManagerService
        _userManagerService;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public UserDeleteDomainFacade(
        IUsersReadRepository
            usersReadRepository,
        IDeleteRepository
            usersRepository,
        IUserManagerService
            userManagerService,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _usersReadRepository =
            usersReadRepository;

        _usersRepository =
            usersRepository;

        _userManagerService =
            userManagerService;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}