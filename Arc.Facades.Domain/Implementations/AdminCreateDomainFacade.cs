using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.DataBase.Models;

namespace Arc.Facades.Domain.Implementations;

public sealed class AdminCreateDomainFacade :
    IAdminCreateDomainFacade
{
    public async Task<int> Create(
        AdminCreateDomainFacadeArgs request
    )
    {
        if (request == default)
        {
            throw
                _badDataExceptionDescriptor.CreateException();
        }

        await
            ValidateCreate(
                request.Email
            );

        var user =
            await
                _userManagerService
                    .CreateIdentityForEmail(
                        request.Email
                    );

        await
            _userManagerService
                .Create(
                    user,
                    request.Password
                );

        await
            _userRoleManagerService
                .AddToRoleAsync(
                    user,
                    ActorTypeConstants.Admin
                );

        var newAdmin =
            new Admin
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

        await
            _adminsRepository
                .CreateAsync(
                    newAdmin
                );

        return
            newAdmin.Id;
    }

    private async Task ValidateCreate(
        string email
    )
    {
        var admin =
            await
                _adminsReadRepository
                    .GetByEmail(
                        email
                    );

        var hasAdmin =
            admin != default;

        if (hasAdmin)
        {
            throw
                _emailUsedByAdminExceptionDescriptor
                    .CreateException();
        }

        var user =
            await
                _usersReadRepository
                    .GetByEmail(
                        email
                    );

        var hasUser =
            user != default;

        if (hasUser)
        {
            throw
                _emailUsedByAdminExceptionDescriptor
                    .CreateException();
        }
    }

#region Constructor

    private readonly IAdminsReadRepository
        _adminsReadRepository;

    private readonly ICreateRepository
        _adminsRepository;

    private readonly IUserManagerService
        _userManagerService;

    private readonly IUserManagerDecorator
        _userRoleManagerService;

    private readonly IUsersReadRepository
        _usersReadRepository;

    private readonly IEmailUsedByAdminExceptionDescriptor
        _emailUsedByAdminExceptionDescriptor;

    private readonly IBadDataExceptionDescriptor
        _badDataExceptionDescriptor;

    public AdminCreateDomainFacade(
        IAdminsReadRepository
            adminsReadRepository,
        ICreateRepository
            adminsRepository,
        IUserManagerService
            userManagerService,
        IUserManagerDecorator
            userRoleManagerService,
        IUsersReadRepository
            usersReadRepository,
        IEmailUsedByAdminExceptionDescriptor
            emailUsedByAdminExceptionDescriptor,
        IBadDataExceptionDescriptor
            badDataExceptionDescriptor
    )
    {
        _adminsReadRepository =
            adminsReadRepository;

        _adminsRepository =
            adminsRepository;

        _userManagerService =
            userManagerService;

        _userRoleManagerService =
            userRoleManagerService;

        _usersReadRepository =
            usersReadRepository;

        _emailUsedByAdminExceptionDescriptor =
            emailUsedByAdminExceptionDescriptor;

        _badDataExceptionDescriptor =
            badDataExceptionDescriptor;
    }

#endregion
}