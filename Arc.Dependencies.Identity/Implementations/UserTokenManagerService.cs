namespace Arc.Dependencies.Identity.Implementations;

public sealed class UserTokenManagerService(
        IUserManagerDecorator
            userManagerDecorator
    )
    :
        IUserTokenManagerService
{
    public async Task<string> GetConfirmationToken(
        IdentityUser user
    ) =>
        await
            userManagerDecorator
                .GenerateEmailConfirmationTokenAsync(
                    user
                );

    public async Task<string> GetPasswordResetToken(
        IdentityUser user
    ) =>
        await
            userManagerDecorator
                .GeneratePasswordResetTokenAsync(
                    user
                );

    public async Task<string> GetEmailChangeToken(
        IdentityUser user,
        string newEmail
    ) =>
        await
            userManagerDecorator
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
            userManagerDecorator
                .RemoveAuthenticationTokenAsync(
                    user,
                    "Auth",
                    "RefreshToken"
                );

        await
            userManagerDecorator
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
            userManagerDecorator
                .GetAuthenticationTokenAsync(
                    user,
                    "Auth",
                    "RefreshToken"
                );
}