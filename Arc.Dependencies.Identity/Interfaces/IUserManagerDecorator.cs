namespace Arc.Dependencies.Identity.Interfaces;

public interface IUserManagerDecorator
{
    Task<IdentityResult> ConfirmEmailAsync(
        IdentityUser user,
        string confirmationCode
    );

    Task<IdentityUser?> FindByIdAsync(
        string id
    );

    Task<IdentityUser?> FindByEmailAsync(
        string email
    );

    Task AddToRoleAsync(
        IdentityUser user,
        string role
    );

    Task<string?> GetAuthenticationTokenAsync(
        IdentityUser user,
        string loginProvider,
        string tokenName
    );

    Task<string> GeneratePasswordResetTokenAsync(
        IdentityUser user
    );

    Task SetAuthenticationTokenAsync(
        IdentityUser user,
        string loginProvider,
        string tokenName,
        string tokenValue
    );

    Task<string> GenerateEmailConfirmationTokenAsync(
        IdentityUser user
    );

    Task<IdentityResult> DeleteAsync(
        IdentityUser user
    );

    Task<IList<string>> GetRolesAsync(
        IdentityUser user
    );

    Task<IdentityResult> CreateAsync(
        IdentityUser user,
        string password
    );

    Task<IdentityResult> ResetPasswordAsync(
        IdentityUser user,
        string token,
        string newPassword
    );

    Task RemoveAuthenticationTokenAsync(
        IdentityUser user,
        string loginProvider,
        string tokenName
    );

    Task<IdentityResult> ChangePasswordAsync(
        IdentityUser user,
        string currentPassword,
        string newPassword
    );

    Task<IdentityResult> RemovePasswordAsync(
        IdentityUser user
    );

    Task<IdentityResult> AddPasswordAsync(
        IdentityUser user,
        string password
    );

    Task<IdentityResult> ChangeEmailAsync(
        IdentityUser user,
        string newEmail,
        string token
    );

    Task<string> GenerateChangeEmailTokenAsync(
        IdentityUser user,
        string newEmail
    );

    Task<IdentityResult> UpdateUserAsync(
        IdentityUser user
    );
}