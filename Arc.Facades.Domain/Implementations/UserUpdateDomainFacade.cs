using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class UserUpdateDomainFacade :
    IUserUpdateDomainFacade
{
    public async Task Update(
        UserUpdateDomainFacadeArgs args
    )
    {
        var user =
            await
                _usersReadRepository
                    .GetById(
                        args.Id
                    );

        if (user == default)
        {
            throw
                _userNotFoundExceptionDescriptor.CreateException();
        }

        user.FirstName =
            args.FirstName;

        user.LastName =
            args.LastName;

        await
            _usersRepository
                .UpdateAsync(
                    user
                );
    }

#region Constructor

    private readonly IUsersReadRepository
        _usersReadRepository;

    private readonly IUpdateRepository
        _usersRepository;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public UserUpdateDomainFacade(
        IUsersReadRepository
            usersReadRepository,
        IUpdateRepository
            usersRepository,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _usersReadRepository =
            usersReadRepository;

        _usersRepository =
            usersRepository;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}