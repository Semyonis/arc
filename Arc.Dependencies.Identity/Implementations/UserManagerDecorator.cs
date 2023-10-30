namespace Arc.Dependencies.Identity.Implementations;

public sealed class UserManagerDecorator :
    IUserManagerDecorator
{
    public async Task AddToRoleAsync(
        IdentityUser user,
        string role
    ) =>
        await
            _userManager
                .AddToRoleAsync(
                    user,
                    role
                );

    public async Task<IList<string>> GetRolesAsync(
        IdentityUser user
    ) =>
        await
            _userManager
                .GetRolesAsync(
                    user
                );

    public async Task<IdentityUser?> FindByIdAsync(
        string id
    ) =>
        await
            _userManager
                .FindByIdAsync(
                    id
                );

    public async Task<IdentityUser?> FindByEmailAsync(
        string email
    ) =>
        await
            _userManager
                .FindByEmailAsync(
                    email
                );

    public Task<IdentityResult> DeleteAsync(
        IdentityUser user
    ) =>
        _userManager
            .DeleteAsync(
                user
            );

    public async Task<IdentityResult> CreateAsync(
        IdentityUser user,
        string password
    ) =>
        await
            _userManager
                .CreateAsync(
                    user,
                    password
                );

    public async Task<IdentityResult> ConfirmEmailAsync(
        IdentityUser user,
        string confirmationCode
    ) =>
        await
            _userManager
                .ConfirmEmailAsync(
                    user,
                    confirmationCode
                );

    public async Task<string> GenerateEmailConfirmationTokenAsync(
        IdentityUser user
    ) =>
        await
            _userManager
                .GenerateEmailConfirmationTokenAsync(
                    user
                );

    public async Task<string> GeneratePasswordResetTokenAsync(
        IdentityUser user
    ) =>
        await
            _userManager
                .GeneratePasswordResetTokenAsync(
                    user
                );

    public async Task<string?> GetAuthenticationTokenAsync(
        IdentityUser user,
        string loginProvider,
        string tokenName
    ) =>
        await
            _userManager
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
            _userManager
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
            _userManager
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
            _userManager
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
            _userManager
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
            _userManager
                .RemovePasswordAsync(
                    user
                );

    public async Task<IdentityResult> AddPasswordAsync(
        IdentityUser user,
        string password
    ) =>
        await
            _userManager
                .AddPasswordAsync(
                    user,
                    password
                );

    public async Task<string> GenerateChangeEmailTokenAsync(
        IdentityUser user,
        string newEmail
    ) =>
        await
            _userManager
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
            _userManager
                .ChangeEmailAsync(
                    user,
                    newEmail,
                    token
                );

    public async Task<IdentityResult> UpdateUserAsync(
        IdentityUser user
    ) =>
        await
            _userManager
                .UpdateAsync(
                    user
                );

#region Constructor

    private readonly UserManager<IdentityUser>
        _userManager;

    public UserManagerDecorator(
        UserManager<IdentityUser>
            userManager
    ) =>
        _userManager =
            userManager;

#endregion
}