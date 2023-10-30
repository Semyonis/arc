namespace Arc.Dependencies.Identity.Interfaces;

public interface ISignInManagerDecorator
{
    Task<SignInResult> PasswordSignIn(
        string name,
        string password
    );
}