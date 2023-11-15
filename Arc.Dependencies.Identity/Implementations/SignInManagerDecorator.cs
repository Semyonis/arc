namespace Arc.Dependencies.Identity.Implementations;

public sealed class SignInManagerDecorator(
        SignInManager<IdentityUser>
            signInManager
    )
    :
        ISignInManagerDecorator
{
    public async Task<SignInResult> PasswordSignIn(
        string name,
        string password
    ) =>
        await
            signInManager
                .PasswordSignInAsync(
                    name,
                    password,
                    true,
                    false
                );
}