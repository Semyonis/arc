namespace Arc.Dependencies.Identity.Interfaces;

public interface IUserPasswordManagerService
{
    Task ResetPassword(
        IdentityUser user,
        string token,
        string newPassword
    );

    Task ChangePassword(
        string email,
        string currentPassword,
        string newPassword
    );

    Task SetPassword(
        string email,
        string password
    );
}