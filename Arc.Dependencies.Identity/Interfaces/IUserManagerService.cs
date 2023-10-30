namespace Arc.Dependencies.Identity.Interfaces;

public interface IUserManagerService
{
    Task ConfirmEmail(
        string userId,
        string code
    );

    Task<IdentityUser?> FindByEmail(
        string email
    );

    Task<IdentityResult> Delete(
        IdentityUser user
    );

    Task<IdentityResult> Create(
        IdentityUser user,
        string password
    );

    Task<IdentityUser> CreateIdentityForEmail(
        string email
    );

    Task ConfirmNewEmail(
        string token,
        string oldEmail,
        string newEmail
    );
}