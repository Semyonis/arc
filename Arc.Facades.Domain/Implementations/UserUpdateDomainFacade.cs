using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class UserUpdateDomainFacade(
        IUsersReadRepository
            usersReadRepository,
        IUpdateRepository
            usersRepository,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    :
        IUserUpdateDomainFacade
{
    public async Task Update(
        UserUpdateDomainFacadeArgs args
    )
    {
        var user =
            await
                usersReadRepository
                    .GetById(
                        args.Id
                    );

        if (user == default)
        {
            throw
                userNotFoundExceptionDescriptor.CreateException();
        }

        user.FirstName =
            args.FirstName;

        user.LastName =
            args.LastName;

        await
            usersRepository
                .UpdateAsync(
                    user
                );
    }
}