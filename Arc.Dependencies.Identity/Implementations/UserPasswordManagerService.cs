using System.Linq;

using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Dependencies.Identity.Implementations;

public sealed class UserPasswordManagerService(
    IUserManagerDecorator
        userManagerDecorator,
    IIdentityErrorExceptionDescriptor
        identityErrorExceptionDescriptor,
    IUserNotFoundExceptionDescriptor
        userNotFoundExceptionDescriptor
) : IUserPasswordManagerService
{
    public async Task ResetPassword(
        IdentityUser user,
        string token,
        string newPassword
    )
    {
        var result =
            await
                userManagerDecorator
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
                identityErrorExceptionDescriptor
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
                userManagerDecorator
                    .FindByEmailAsync(
                        email
                    );

        if (user == default)
        {
            throw
                userNotFoundExceptionDescriptor
                    .CreateException(
                        email
                    );
        }

        var result =
            await
                userManagerDecorator
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
                identityErrorExceptionDescriptor
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
                userManagerDecorator
                    .FindByEmailAsync(
                        email
                    );

        if (identityUser == default)
        {
            throw
                userNotFoundExceptionDescriptor
                    .CreateException(
                        email
                    );
        }

        var result =
            await
                userManagerDecorator
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
                identityErrorExceptionDescriptor
                    .CreateException(
                        errorCode
                    );
        }

        result =
            await
                userManagerDecorator
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
                identityErrorExceptionDescriptor
                    .CreateException(
                        errorCode
                    );
        }
    }
}