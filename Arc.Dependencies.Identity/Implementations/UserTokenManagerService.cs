namespace Arc.Dependencies.Identity.Implementations;

public sealed class UserTokenManagerService :
    IUserTokenManagerService
{
    public async Task<string> GetConfirmationToken(
        IdentityUser user
    ) =>
        await
            _userManagerDecorator
                .GenerateEmailConfirmationTokenAsync(
                    user
                );

    public async Task<string> GetPasswordResetToken(
        IdentityUser user
    ) =>
        await
            _userManagerDecorator
                .GeneratePasswordResetTokenAsync(
                    user
                );

    public async Task<string> GetEmailChangeToken(
        IdentityUser user,
        string newEmail
    ) =>
        await
            _userManagerDecorator
                .GenerateChangeEmailTokenAsync(
                    user,
                    newEmail
                );

    public async Task RefreshAuthenticationToken(
        IdentityUser user,
        string token
    )
    {
        await
            _userManagerDecorator
                .RemoveAuthenticationTokenAsync(
                    user,
                    "Auth",
                    "RefreshToken"
                );

        await
            _userManagerDecorator
                .SetAuthenticationTokenAsync(
                    user,
                    "Auth",
                    "RefreshToken",
                    token
                );
    }

    public async Task<string?> GetAuthenticationToken(
        IdentityUser user
    ) =>
        await
            _userManagerDecorator
                .GetAuthenticationTokenAsync(
                    user,
                    "Auth",
                    "RefreshToken"
                );

#region Constructor

    private readonly IUserManagerDecorator
        _userManagerDecorator;

    public UserTokenManagerService(
        IUserManagerDecorator
            userManagerDecorator
    ) =>
        _userManagerDecorator =
            userManagerDecorator;

#endregion
}