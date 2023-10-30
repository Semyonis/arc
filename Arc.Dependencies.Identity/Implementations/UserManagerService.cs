using System;
using System.Linq;

using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Dependencies.Identity.Implementations;

public sealed class UserManagerService :
    IUserManagerService
{
    public async Task<IdentityUser?> FindByEmail(
        string email
    ) =>
        await
            _userManagerDecorator
                .FindByEmailAsync(
                    email
                );

    public Task<IdentityResult> Delete(
        IdentityUser user
    ) =>
        _userManagerDecorator
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
                _userManagerDecorator
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
            _identityErrorExceptionDescriptor
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
                _emailUsedByUserExceptionDescriptor
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
                _userManagerDecorator
                    .FindByIdAsync(
                        userId
                    );

        if (user == default)
        {
            throw
                _userNotFoundExceptionDescriptor
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
                _identityErrorExceptionDescriptor
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
                _userManagerDecorator
                    .FindByEmailAsync(
                        oldEmail
                    );

        if (user == default)
        {
            throw
                _userNotFoundExceptionDescriptor
                    .CreateException(
                        oldEmail
                    );
        }

        var result =
            await
                _userManagerDecorator
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
                _identityErrorExceptionDescriptor
                    .CreateException(
                        errorCode
                    );
        }

        user =
            await
                _userManagerDecorator
                    .FindByEmailAsync(
                        newEmail
                    );

        user!.UserName =
            newEmail;

        await
            _userManagerDecorator
                .UpdateUserAsync(
                    user
                );
    }

    private async Task<IdentityResult> ConfirmEmail(
        IdentityUser user,
        string confirmationCode
    ) =>
        await
            _userManagerDecorator
                .ConfirmEmailAsync(
                    user,
                    confirmationCode
                );

#region Constructor

    private readonly IEmailUsedByUserExceptionDescriptor
        _emailUsedByUserExceptionDescriptor;

    private readonly IIdentityErrorExceptionDescriptor
        _identityErrorExceptionDescriptor;

    private readonly IUserManagerDecorator
        _userManagerDecorator;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public UserManagerService(
        IUserManagerDecorator
            userManagerDecorator,
        IEmailUsedByUserExceptionDescriptor
            emailUsedByUserExceptionDescriptor,
        IIdentityErrorExceptionDescriptor
            identityErrorExceptionDescriptor,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _userManagerDecorator =
            userManagerDecorator;

        _emailUsedByUserExceptionDescriptor =
            emailUsedByUserExceptionDescriptor;

        _identityErrorExceptionDescriptor =
            identityErrorExceptionDescriptor;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}