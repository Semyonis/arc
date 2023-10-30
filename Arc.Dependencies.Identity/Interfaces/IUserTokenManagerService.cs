namespace Arc.Dependencies.Identity.Interfaces;

public interface IUserTokenManagerService
{
    Task<string> GetConfirmationToken(
        IdentityUser user
    );

    Task<string> GetPasswordResetToken(
        IdentityUser user
    );

    Task RefreshAuthenticationToken(
        IdentityUser user,
        string token
    );

    Task<string?> GetAuthenticationToken(
        IdentityUser user
    );

    Task<string> GetEmailChangeToken(
        IdentityUser user,
        string newEmail
    );
}