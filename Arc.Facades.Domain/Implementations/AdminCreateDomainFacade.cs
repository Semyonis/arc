using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.DataBase.Models;

namespace Arc.Facades.Domain.Implementations;

public sealed class AdminCreateDomainFacade(
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
    :
        IAdminCreateDomainFacade
{
    public async Task<int> Create(
        AdminCreateDomainFacadeArgs request
    )
    {
        if (request == default)
        {
            throw
                badDataExceptionDescriptor.CreateException();
        }

        await
            ValidateCreate(
                request.Email
            );

        var user =
            await
                userManagerService
                    .CreateIdentityForEmail(
                        request.Email
                    );

        await
            userManagerService
                .Create(
                    user,
                    request.Password
                );

        await
            userRoleManagerService
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
            adminsRepository
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
                adminsReadRepository
                    .GetByEmail(
                        email
                    );

        var hasAdmin =
            admin != default;

        if (hasAdmin)
        {
            throw
                emailUsedByAdminExceptionDescriptor
                    .CreateException();
        }

        var user =
            await
                usersReadRepository
                    .GetByEmail(
                        email
                    );

        var hasUser =
            user != default;

        if (hasUser)
        {
            throw
                emailUsedByAdminExceptionDescriptor
                    .CreateException();
        }
    }
}