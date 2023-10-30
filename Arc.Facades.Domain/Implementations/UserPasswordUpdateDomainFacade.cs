using Arc.Dependencies.Identity.Interfaces;
using Arc.Facades.Domain.Args;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;

namespace Arc.Facades.Domain.Implementations;

public sealed class UserPasswordUpdateDomainFacade :
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
                _userManagerService
                    .FindByEmail(
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

        var resetToken =
            await
                _userTokenManagerService
                    .GetPasswordResetToken(
                        user
                    );

        await
            _userPasswordManagerService
                .ResetPassword(
                    user,
                    resetToken,
                    password
                );
    }

#region Constructor

    private readonly IUserManagerService
        _userManagerService;

    private readonly IUserTokenManagerService
        _userTokenManagerService;

    private readonly IUserPasswordManagerService
        _userPasswordManagerService;

    private readonly IUserNotFoundExceptionDescriptor
        _userNotFoundExceptionDescriptor;

    public UserPasswordUpdateDomainFacade(
        IUserManagerService
            userManagerService,
        IUserTokenManagerService
            userTokenManagerService,
        IUserPasswordManagerService
            userPasswordManagerService,
        IUserNotFoundExceptionDescriptor
            userNotFoundExceptionDescriptor
    )
    {
        _userManagerService =
            userManagerService;

        _userTokenManagerService =
            userTokenManagerService;

        _userPasswordManagerService =
            userPasswordManagerService;

        _userNotFoundExceptionDescriptor =
            userNotFoundExceptionDescriptor;
    }

#endregion
}