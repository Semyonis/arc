using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class UserPasswordUpdateDomainFacade(
        IUserManagerService
            userManagerService,
        IUserTokenManagerService
            userTokenManagerService,
        IUserPasswordManagerService
            userPasswordManagerService,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    :
        IUserPasswordUpdateDomainFacade
{
    public async Task ChangePassword(
        UserPasswordUpdateDomainFacadeArgs args
    )
    {
        (
            var email,
            var password
        ) = args;

        var user =
            await
                userManagerService
                    .FindByEmail(
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

        var resetToken =
            await
                userTokenManagerService
                    .GetPasswordResetToken(
                        user
                    );

        await
            userPasswordManagerService
                .ResetPassword(
                    user,
                    resetToken,
                    password
                );
    }
}