using System.Linq;

using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Dependencies.Identity.Implementations;

public sealed class UserPasswordManagerService :
    IUserPasswordManagerService
{
    public async Task ResetPassword(
        IdentityUser user,
        string token,
        string newPassword
    )
    {
        var result =
            await
                _userManagerDecorator
                    .ResetPasswordAsync(
                        user,
                        token,
                        newPassword
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

    public async Task ChangePassword(
        string email,
        string currentPassword,
        string newPassword
    )
    {
        var user =
            await
                _userManagerDecorator
                    .FindByEmailAsync(
                        email
                    );

        if (user == default)
        {
            throw
                _userNotFoundExceptionDescriptor
                    .CreateException(
                        email
                    );
        }

        var result =
            await
                _userManagerDecorator
                    .ChangePasswordAsync(
                        user,
                        currentPassword,
                        newPassword
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

    public async Task SetPassword(
        string email,
        string password
    )
    {
        var identityUser =
            await
                _userManagerDecorator
                    .FindByEmailAsync(
                        email
                    );

        if (identityUser == default)
        {
            throw
                _userNotFoundExceptionDescriptor
                    .CreateException(
                        email
                    );
        }

        var result =
            await
                _userManagerDecorator
                    .RemovePasswordAsync(
                        identityUser
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

        result =
            await
                _userManagerDecorator
                    .AddPasswordAsync(
                        identityUser,
                        password
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

#region Constructor

    private readonly IIdentityErrorExceptionDescriptor
        _identityErrorExceptionDescriptor;

    private readonly IUserManagerDecorator
        _userManagerDecorator;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public UserPasswordManagerService(
        IUserManagerDecorator
            userManagerDecorator,
        IIdentityErrorExceptionDescriptor
            identityErrorExceptionDescriptor,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _userManagerDecorator =
            userManagerDecorator;

        _identityErrorExceptionDescriptor =
            identityErrorExceptionDescriptor;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}