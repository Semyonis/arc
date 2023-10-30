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

public sealed class UserCreateDomainFacade :
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
            _userPropertyFilters
                .GetEmailEqualFilter(
                    args.Email
                );

        var users =
            await
                _usersReadRepository
                    .GetListByFiltersAsync(
                        propertyFilterParameter.WrapByReadOnlyList()
                    );

        if (users.IsNotEmpty())
        {
            throw
                _usedByUserExceptionDescriptor
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
            _usersRepository
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
                _userManagerService
                    .CreateIdentityForEmail(
                        args.Email
                    );

        await
            _userManagerService
                .Create(
                    user,
                    args.Password
                );

        await
            _userRoleManagerService
                .AddToRoleAsync(
                    user,
                    ActorTypeConstants.User
                );
    }

#region Constructor

    private readonly IUserManagerService
        _userManagerService;

    private readonly ICreateRepository
        _usersRepository;

    private readonly IUsersReadRepository
        _usersReadRepository;

    private readonly IUserManagerDecorator
        _userRoleManagerService;

    private readonly IEmailUsedByUserExceptionDescriptor
        _usedByUserExceptionDescriptor;

    private readonly IUserPropertyFilters
        _userPropertyFilters;

    public UserCreateDomainFacade(
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
    {
        _usersRepository =
            usersRepository;

        _userManagerService =
            userManagerService;

        _userRoleManagerService =
            userRoleManagerService;

        _usersReadRepository =
            usersReadRepository;

        _usedByUserExceptionDescriptor =
            usedByUserExceptionDescriptor;

        _userPropertyFilters =
            userPropertyFilters;
    }

#endregion
}