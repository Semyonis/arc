namespace Arc.Dependencies.Identity.Implementations;

public sealed class UserManagerDecorator(
    UserManager<IdentityUser>
        userManager
) : IUserManagerDecorator
{
    public async Task AddToRoleAsync(
        IdentityUser user,
        string role
    ) =>
        await
            userManager
                .AddToRoleAsync(
                    user,
                    role
                );

    public async Task<IList<string>> GetRolesAsync(
        IdentityUser user
    ) =>
        await
            userManager
                .GetRolesAsync(
                    user
                );

    public async Task<IdentityUser?> FindByIdAsync(
        string id
    ) =>
        await
            userManager
                .FindByIdAsync(
                    id
                );

    public async Task<IdentityUser?> FindByEmailAsync(
        string email
    ) =>
        await
            userManager
                .FindByEmailAsync(
                    email
                );

    public Task<IdentityResult> DeleteAsync(
        IdentityUser user
    ) =>
        userManager
            .DeleteAsync(
                user
            );

    public async Task<IdentityResult> CreateAsync(
        IdentityUser user,
        string password
    ) =>
        await
            userManager
                .CreateAsync(
                    user,
                    password
                );

    public async Task<IdentityResult> ConfirmEmailAsync(
        IdentityUser user,
        string confirmationCode
    ) =>
        await
            userManager
                .ConfirmEmailAsync(
                    user,
                    confirmationCode
                );

    public async Task<string> GenerateEmailConfirmationTokenAsync(
        IdentityUser user
    ) =>
        await
            userManager
                .GenerateEmailConfirmationTokenAsync(
                    user
                );

    public async Task<string> GeneratePasswordResetTokenAsync(
        IdentityUser user
    ) =>
        await
            userManager
                .GeneratePasswordResetTokenAsync(
                    user
                );

    public async Task<string?> GetAuthenticationTokenAsync(
        IdentityUser user,
        string loginProvider,
        string tokenName
    ) =>
        await
            userManager
                .GetAuthenticationTokenAsync(
                    user,
                    loginProvider,
                    tokenName
                );

    public async Task<IdentityResult> ResetPasswordAsync(
        IdentityUser user,
        string token,
        string newPassword
    ) =>
        await
            userManager
                .ResetPasswordAsync(
                    user,
                    token,
                    newPassword
                );

    public async Task<IdentityResult> ChangePasswordAsync(
        IdentityUser user,
        string currentPassword,
        string newPassword
    ) =>
        await
            userManager
                .ChangePasswordAsync(
                    user,
                    currentPassword,
                    newPassword
                );

    public async Task RemoveAuthenticationTokenAsync(
        IdentityUser user,
        string loginProvider,
        string tokenName
    ) =>
        await
            userManager
                .RemoveAuthenticationTokenAsync(
                    user,
                    loginProvider,
                    tokenName
                );

    public async Task SetAuthenticationTokenAsync(
        IdentityUser user,
        string loginProvider,
        string tokenName,
        string tokenValue
    ) =>
        await
            userManager
                .SetAuthenticationTokenAsync(
                    user,
                    loginProvider,
                    tokenName,
                    tokenValue
                );

    public async Task<IdentityResult> RemovePasswordAsync(
        IdentityUser user
    ) =>
        await
            userManager
                .RemovePasswordAsync(
                    user
                );

    public async Task<IdentityResult> AddPasswordAsync(
        IdentityUser user,
        string password
    ) =>
        await
            userManager
                .AddPasswordAsync(
                    user,
                    password
                );

    public async Task<string> GenerateChangeEmailTokenAsync(
        IdentityUser user,
        string newEmail
    ) =>
        await
            userManager
                .GenerateChangeEmailTokenAsync(
                    user,
                    newEmail
                );

    public async Task<IdentityResult> ChangeEmailAsync(
        IdentityUser user,
        string newEmail,
        string token
    ) =>
        await
            userManager
                .ChangeEmailAsync(
                    user,
                    newEmail,
                    token
                );

    public async Task<IdentityResult> UpdateUserAsync(
        IdentityUser user
    ) =>
        await
            userManager
                .UpdateAsync(
                    user
                );
}