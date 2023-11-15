using Arc.Criteria.PropertyFilters.Interfaces;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.DataBase.Models;

namespace Arc.Facades.Domain.Implementations;

public sealed class UserCreateDomainFacade(
        ICreateRepository
            usersRepository,
        IUserManagerService
            userManagerService,
        IUserManagerDecorator
            userRoleManagerService,
        IUsersReadRepository
            usersReadRepository,
        IEmailUsedByUserExceptionDescriptor
            usedByUserExceptionDescriptor,
        IUserPropertyFilters
            userPropertyFilters
    )
    :
        IUserCreateDomainFacade
{
    public async Task Create(
        CreateUserDomainFacadeArgs args
    )
    {
        await
            CreateUser(
                args
            );

        await
            SetUpIdentity(
                args
            );
    }

    private async Task CreateUser(
        CreateUserDomainFacadeArgs args
    )
    {
        var propertyFilterParameter =
            userPropertyFilters
                .GetEmailEqualFilter(
                    args.Email
                );

        var users =
            await
                usersReadRepository
                    .GetListByFiltersAsync(
                        propertyFilterParameter.WrapByReadOnlyList()
                    );

        if (users.IsNotEmpty())
        {
            throw
                usedByUserExceptionDescriptor
                    .CreateException();
        }

        var user =
            new User
            {
                Email = args.Email,
                FirstName = args.FirstName,
                LastName = args.LastName,
            };

        await
            usersRepository
                .CreateAsync(
                    user
                );
    }

    private async Task SetUpIdentity(
        CreateUserDomainFacadeArgs args
    )
    {
        var user =
            await
                userManagerService
                    .CreateIdentityForEmail(
                        args.Email
                    );

        await
            userManagerService
                .Create(
                    user,
                    args.Password
                );

        await
            userRoleManagerService
                .AddToRoleAsync(
                    user,
                    ActorTypeConstants.User
                );
    }
}