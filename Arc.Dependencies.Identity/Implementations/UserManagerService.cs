using System;
using System.Linq;

using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Dependencies.Identity.Implementations;

public sealed class UserManagerService(
    IUserManagerDecorator
        userManagerDecorator,
    IEmailUsedByUserExceptionDescriptor
        emailUsedByUserExceptionDescriptor,
    IIdentityErrorExceptionDescriptor
        identityErrorExceptionDescriptor,
    IUserNotFoundExceptionDescriptor
        userNotFoundExceptionDescriptor
) : IUserManagerService
{
    public async Task<IdentityUser?> FindByEmail(
        string email
    ) =>
        await
            userManagerDecorator
                .FindByEmailAsync(
                    email
                );

    public Task<IdentityResult> Delete(
        IdentityUser user
    ) =>
        userManagerDecorator
            .DeleteAsync(
                user
            );

    public async Task<IdentityResult> Create(
        IdentityUser user,
        string password
    )
    {
        var identityResult =
            await
                userManagerDecorator
                    .CreateAsync(
                        user,
                        password
                    );

        if (identityResult.Succeeded)
        {
            return
                identityResult;
        }

        var errorCode =
            identityResult
                .Errors
                .First()
                .Code;

        throw
            identityErrorExceptionDescriptor
                .CreateException(
                    errorCode
                );
    }

    public async Task<IdentityUser> CreateIdentityForEmail(
        string email
    )
    {
        var user =
            await
                FindByEmail(
                    email
                );

        if (user != default)
        {
            throw
                emailUsedByUserExceptionDescriptor
                    .CreateException();
        }

        var securityStamp =
            Guid
                .NewGuid()
                .ToString();

        return new()
        {
            Email = email,
            UserName = email,
            SecurityStamp = securityStamp,
        };
    }

    public async Task ConfirmEmail(
        string userId,
        string code
    )
    {
        var user =
            await
                userManagerDecorator
                    .FindByIdAsync(
                        userId
                    );

        if (user == default)
        {
            throw
                userNotFoundExceptionDescriptor
                    .CreateException(
                        userId
                    );
        }

        var result =
            await
                ConfirmEmail(
                    user,
                    code
                );

        if (!result.Succeeded)
        {
            var errorCode =
                result
                    .Errors
                    .First()
                    .Code;

            throw
                identityErrorExceptionDescriptor
                    .CreateException(
                        errorCode
                    );
        }
    }

    public async Task ConfirmNewEmail(
        string token,
        string oldEmail,
        string newEmail
    )
    {
        var user =
            await
                userManagerDecorator
                    .FindByEmailAsync(
                        oldEmail
                    );

        if (user == default)
        {
            throw
                userNotFoundExceptionDescriptor
                    .CreateException(
                        oldEmail
                    );
        }

        var result =
            await
                userManagerDecorator
                    .ChangeEmailAsync(
                        user,
                        newEmail,
                        token
                    );

        if (!result.Succeeded)
        {
            var errorCode =
                result
                    .Errors
                    .First()
                    .Code;

            throw
                identityErrorExceptionDescriptor
                    .CreateException(
                        errorCode
                    );
        }

        user =
            await
                userManagerDecorator
                    .FindByEmailAsync(
                        newEmail
                    );

        user!.UserName =
            newEmail;

        await
            userManagerDecorator
                .UpdateUserAsync(
                    user
                );
    }

    private async Task<IdentityResult> ConfirmEmail(
        IdentityUser user,
        string confirmationCode
    ) =>
        await
            userManagerDecorator
                .ConfirmEmailAsync(
                    user,
                    confirmationCode
                );
}